using System.Globalization;
using System.Text.RegularExpressions;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using iText.IO.Font;
using iText.IO.Font.Constants;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using MediatR;
using Path = System.IO.Path;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.CreatePdf;

public class CreatePdfCommandHandler : IRequestHandler<CreatePdfCommand, Unit>
{
    public async Task<Unit> Handle(CreatePdfCommand request, CancellationToken cancellationToken)
    {
        await using var stream = new MemoryStream();
        await using var writer = new PdfWriter($"./{request.Invoice.InvoiceNumber.Value}.pdf");
        using var pdfDocument = new PdfDocument(writer);
        using var document = new Document(pdfDocument, PageSize.A4);
            
        var (helvetica, helveticaBold) = SetFonts();
        SetSummedPrices(request, out var sumNet, out var sumVat, out var sumGross, out var sumByVat);
            
        SetHeaderTable(request, helvetica, helveticaBold, document);
        SetContractorsTable(request, helveticaBold, helvetica, document);
        SetProductsTable(request, helvetica, helveticaBold, document, sumNet, sumVat, sumGross, sumByVat);
        SetSummaryTable(request, helveticaBold, helvetica, document, sumGross);
            
        document.Close();
        return await Task.FromResult(Unit.Value);
    }
    
    private (PdfFont helvetica, PdfFont helveticaBold) SetFonts()
    {
        var helvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA, PdfEncodings.CP1257);
        var helveticaBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD, PdfEncodings.CP1257);
        return (helvetica, helveticaBold);
    }
    
    private void SetSummedPrices(CreatePdfCommand request, out decimal sumNet, out decimal sumVat, out decimal sumGross,
        out SortedDictionary<string, PriceByVat> sumByVat)
    {
        sumNet = 0m;
        sumVat = 0m;
        sumGross = 0m;
    
        sumByVat = new SortedDictionary<string, PriceByVat>();
    
        foreach (var product in request.Invoice.Products)
        {
            sumNet = Math.Round(sumNet + product.Product.PriceNet.Value * product.NumberOfUnits.Value, 2);
            sumVat = Math.Round(sumVat + product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2);
            sumGross = Math.Round(
                sumGross + product.Product.PriceNet.Value * product.NumberOfUnits.Value +
                product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2);
    
            var key = product.Product.Vat.Value switch
            {
                0 => product.Product.IsVatZw.Value ? "zw" : "0",
                _ => product.Product.Vat.Value.ToString(CultureInfo.InvariantCulture)
            };
    
            if (sumByVat.ContainsKey(key))
            {
                // var (_, value) = sumByVat.Single(s => Math.Abs(int.Parse(s.Key) - product.Product.Vat.Value) < 0.1);
    
                var (_, value) = sumByVat.Single(s =>
                    Math.Abs(s.Key == "zw" ? 0 : int.Parse(s.Key) - product.Product.Vat.Value) < 0.1m);
                    
                value.NetPrice = Math.Round(value.NetPrice + product.Product.PriceNet.Value * product.NumberOfUnits.Value, 2);
                value.VatPrice =
                    Math.Round(value.VatPrice + product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2);
                value.GrossPrice =
                    Math.Round(
                        value.GrossPrice + product.Product.PriceNet.Value * product.NumberOfUnits.Value +
                        product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2);
            }
            else
            {
                sumByVat.Add(key , new PriceByVat
                {
                    NetPrice = Math.Round(product.Product.PriceNet.Value * product.NumberOfUnits.Value, 2),
                    VatPrice = Math.Round(product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2),
                    GrossPrice =
                        Math.Round(
                            product.Product.PriceNet.Value * product.NumberOfUnits.Value +
                            product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2),
                    IsVatZw = product.Product.IsVatZw.Value
                });
            }
        }
    }
    
    private void SetContractorsTable(CreatePdfCommand request, PdfFont helveticaBold, PdfFont helvetica, Document document)
    {
        var contractorsTable = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();
    
        var seller = new Paragraph("SPRZEDAWCA:\n");
        var buyer = new Paragraph("NABYWCA:\n").SetTextAlignment(TextAlignment.RIGHT);
    
        if (string.IsNullOrWhiteSpace(request.Invoice.Seller.Address.Street.Value))
        {
            seller.Add(new Text($"{request.Invoice.Seller.Name.Value}\n").SetFont(helveticaBold).SetFontSize(20));
                
            if (request.Invoice.Seller.Address.FlatNumber?.Value is not null)
            {
                seller.Add(
                        $"{request.Invoice.Seller.Address.PostCode.Value} {request.Invoice.Seller.Address.PostCity.Value} {request.Invoice.Seller.Address.BuildingNumber.Value}/{request.Invoice.Seller.Address.FlatNumber.Value}\n")
                    .SetFont(helvetica);
            }
            else
            {
                seller.Add(
                        $"{request.Invoice.Seller.Address.PostCode.Value} {request.Invoice.Seller.Address.PostCity.Value} {request.Invoice.Seller.Address.BuildingNumber.Value}\n")
                    .SetFont(helvetica);
            }
                
            if (string.IsNullOrWhiteSpace(request.Invoice.Seller.Nip?.Value) == false)
                seller.Add($"NIP: {request.Invoice.Seller.Nip.Value}").SetFont(helvetica);
        }
        else
        {
            seller.Add(new Text($"{request.Invoice.Seller.Name.Value}\n").SetFont(helveticaBold).SetFontSize(20));
            if (request.Invoice.Seller.Address.FlatNumber?.Value is not null)
            {
                seller.Add(
                        $"{request.Invoice.Seller.Address.Street.Value} {request.Invoice.Seller.Address.BuildingNumber.Value}/{request.Invoice.Seller.Address.FlatNumber.Value}\n")
                    .SetFont(helvetica);
            }
            else
            {
                seller.Add(
                        $"{request.Invoice.Seller.Address.Street.Value} {request.Invoice.Seller.Address.BuildingNumber.Value}\n")
                    .SetFont(helvetica);
            }
            seller.Add($"{request.Invoice.Seller.Address.PostCode.Value} {request.Invoice.Seller.Address.PostCity.Value}\n")
                .SetFont(helvetica);
            if (string.IsNullOrWhiteSpace(request.Invoice.Seller.Nip?.Value) == false)
                seller.Add($"NIP: {request.Invoice.Seller.Nip.Value}").SetFont(helvetica);
        }
    
        if (string.IsNullOrWhiteSpace(request.Invoice.Buyer.Address.Street.Value))
        {
            buyer.Add(new Text($"{request.Invoice.Buyer.Name.Value}\n").SetFont(helveticaBold).SetFontSize(20));
                
            if (request.Invoice.Buyer.Address.FlatNumber?.Value is not null)
            {
                buyer.Add(
                        $"{request.Invoice.Buyer.Address.PostCode} {request.Invoice.Buyer.Address.PostCity.Value} {request.Invoice.Buyer.Address.BuildingNumber.Value}/{request.Invoice.Buyer.Address.FlatNumber.Value}\n")
                    .SetFont(helvetica);
            }
            else
            {
                buyer.Add(
                        $"{request.Invoice.Buyer.Address.PostCode.Value} {request.Invoice.Buyer.Address.PostCity.Value} {request.Invoice.Buyer.Address.BuildingNumber.Value}\n")
                    .SetFont(helvetica);
            }
    
            if (string.IsNullOrWhiteSpace(request.Invoice.Buyer.Nip?.Value) == false)
                buyer.Add($"NIP: {request.Invoice.Buyer.Nip.Value}").SetFont(helvetica);
        }
        else
        {
            buyer.Add(new Text($"{request.Invoice.Buyer.Name.Value}\n").SetFont(helveticaBold).SetFontSize(20));
                
            if (request.Invoice.Buyer.Address.FlatNumber?.Value is not null)
            {
                buyer.Add(
                        $"{request.Invoice.Buyer.Address.Street.Value} {request.Invoice.Buyer.Address.BuildingNumber.Value}/{request.Invoice.Buyer.Address.FlatNumber.Value}\n")
                    .SetFont(helvetica);
            }
            else
            {
                buyer.Add(
                        $"{request.Invoice.Buyer.Address.Street.Value} {request.Invoice.Buyer.Address.BuildingNumber.Value}\n")
                    .SetFont(helvetica);
            }
                
            buyer.Add($"{request.Invoice.Buyer.Address.PostCode.Value} {request.Invoice.Buyer.Address.PostCity.Value}\n")
                .SetFont(helvetica);
            if (string.IsNullOrWhiteSpace(request.Invoice.Buyer.Nip?.Value) == false)
                buyer.Add($"NIP: {request.Invoice.Buyer.Nip.Value}").SetFont(helvetica);
        }
    
        var sellerCell = new Cell().Add(seller);
        sellerCell.SetBorder(Border.NO_BORDER);
        contractorsTable.AddCell(sellerCell);
    
        var buyerCell = new Cell().Add(buyer);
        buyerCell.SetBorder(Border.NO_BORDER);
        contractorsTable.AddCell(buyerCell);
        contractorsTable.SetMarginBottom(20);
            
        document.Add(contractorsTable);
    }
    
    private void SetHeaderTable(CreatePdfCommand request, PdfFont helvetica, PdfFont helveticaBold, Document document)
    {
        var headerTable = new Table(UnitValue.CreatePercentArray(2)).UseAllAvailableWidth();

        SetLogo(request, headerTable);
            
        var invoiceDate =
            new Paragraph("FAKTURA ").SetFont(helvetica).SetFontSize(14)
                .Add(new Text($"{request.Invoice.InvoiceNumber.Value}\n").SetFont(helveticaBold))
                .Add($"data wystawienia: {request.Invoice.DateOfInvoice.Value.ToShortDateString()}\n").SetFont(helvetica)
                .Add($"data wydania towaru: {request.Invoice.DateOfRelease.Value.ToShortDateString()}").SetFont(helvetica)
                .SetTextAlignment(TextAlignment.RIGHT);

        var dateCell = new Cell().Add(invoiceDate).SetVerticalAlignment(VerticalAlignment.MIDDLE);
        dateCell.SetBorder(Border.NO_BORDER);
        headerTable.AddCell(dateCell);
        headerTable.SetMarginBottom(20);
            
        document.Add(headerTable);
    }

    private void SetLogo(CreatePdfCommand request, Table headerTable)
    {
        Image? logo;
        if (request.IsWithLogo == false)
        {
            logo = new Image(ImageDataFactory.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "blank-logo.png")));
        }
        else
        {
            try
            {
                logo = new Image(ImageDataFactory.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "blublu-logo.png")));
            }
            catch (Exception)
            {
                try
                {
                    logo = new Image(ImageDataFactory.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "blublu-logo.jpg")));
                }
                catch (Exception)
                {
                    logo = new Image(ImageDataFactory.Create(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "blank-logo.png")));
                    //TODO come up with better idea
                }
            }
        }

        logo.ScaleToFit(128, 128);
        var image = new Paragraph().Add(logo);
        var nameCell = new Cell().Add(image);
        nameCell.SetBorder(Border.NO_BORDER);
        headerTable.AddCell(nameCell);
    }

    private void SetProductsTable(
        CreatePdfCommand request,
        PdfFont helvetica,
        PdfFont helveticaBold,
        Document document,
        decimal sumNet,
        decimal sumVat,
        decimal sumGross,
        SortedDictionary<string, PriceByVat> sumByVat)
    {
        var productsTable = new Table(UnitValue.CreatePercentArray(18)).UseAllAvailableWidth();
            
        AddCell("LP.", false, true, 1, 6);
        AddCell("NAZWA", false, true, 4, 6);
        AddCell("PODSTAWA ZWOLNIENIA", false, true, 2, 6);
        AddCell("CENA", false, true, 1, 6);
        AddCell("ILOŚĆ", false, true, 1, 6);
        AddCell("J.M.", false, true, 1, 6);
        AddCell("KWOTA NETTO", false, true, 2, 6);
        AddCell("STAWKA VAT", false, true, 2, 6);
        AddCell("VAT", false, true, 2, 6);
        AddCell("KWOTA BRUTTO", false, true, 3, 6);
    
        var count = 1;
        foreach (var product in request.Invoice.Products)
        {
            AddCell($"{count}", true, false, 1);
            AddCell($"{product.Product.Name.Value}", true, false, 4);
            AddCell($"{product.Product.LegalBasisForTaxExemption?.Value}", true, false, 2);
            AddCell($"{product.Product.PriceNet.Value:0.00}", true, false, 1);
            AddCell($"{product.NumberOfUnits.Value}", true, false, 1);
            AddCell($"{product.Product.UnitName.Value}", true, false, 1);
            AddCell($"{Math.Round(product.Product.PriceNet.Value * product.NumberOfUnits.Value, 2):0.00}", true, false, 2);
            AddCell(product.Product.IsVatZw.Value ? "zw" : $"{product.Product.Vat.Value}%", true, false, 2);
            AddCell($"{Math.Round(product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2):0.00}", true, false, 2);
            AddCell($"{Math.Round(product.Product.PriceNet.Value * product.NumberOfUnits.Value + product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2):0.00}", true, false, 3);
            count++;
        }
            
        AddCell("", true, false, 1);
        AddCell("", true, false, 4);
        AddCell("", true, false, 2);
        AddCell("", true, false, 1);
        AddCell("Razem", true, true, 2);
        AddCell($"{sumNet:0.00}", true, false, 2);
        AddCell("", true, false, 2);
        AddCell($"{sumVat:0.00}", true, false, 2);
        AddCell($"{sumGross:0.00}", true, false, 3);
            
        foreach (var (key, value) in sumByVat)
        {
            AddCell("", true, false, 1);
            AddCell("", true, false, 4);
            AddCell("", true, false, 2);
            AddCell("", true, false, 1);
            AddCell("w tym", true, true, 2);
            AddCell($"{value.NetPrice:0.00}", true, false, 2);
            AddCell(value.IsVatZw ? "zw" : $"{key}%", true, false, 2);
            AddCell($"{value.VatPrice:0.00}", true, false, 2);
            AddCell($"{value.GrossPrice:0.00}", true, false, 3);
        }
        productsTable.SetMarginBottom(20);
        document.Add(productsTable);
    
        void AddCell(string value, bool noBorder, bool isBold, int cellColumnSpan, int fontSize = 8)
        {
            var cell = new Cell(1,cellColumnSpan).Add(new Paragraph(value).SetFont(isBold ? helveticaBold : helvetica).SetFontSize(fontSize));
            if (noBorder)
            {
                cell.SetBorder(Border.NO_BORDER);
            }
            else
            {
                cell.SetBorderTop(Border.NO_BORDER);
                cell.SetBorderLeft(Border.NO_BORDER);
                cell.SetBorderRight(Border.NO_BORDER);
                cell.SetBorderBottom(new SolidBorder(ColorConstants.DARK_GRAY, 1, 0.3f));
            }
                
            productsTable.AddCell(cell);
        }
    }
        
    private void SetSummaryTable(CreatePdfCommand request, PdfFont helveticaBold, PdfFont helvetica, Document document, decimal sumGross)
    {
        var summaryTable = new Table(UnitValue.CreatePercentArray(4)).SetWidth(UnitValue.CreatePercentValue(70));
            
        AddCell("Razem do zapłaty:", false);
        AddCell($"{sumGross:0.00}", true, 15);
        AddCell("Termin płatności:", false);
        AddCell($"{request.Invoice.DateOfPayment.Value.ToShortDateString()}", true);
        AddCell("Forma płatności:", false);
        AddCell($"{request.Invoice.FormOfPayment}", true);
        AddCell("Numer konta:", false);
        AddCell($"{PrepareAccountNumber(request.Invoice.AccountNumber.Value!)}", true);
        AddCell("Płatność podzielona:", false);
        AddCell($"{PreparePaymentDivided(request.Invoice.IsPaymentDivided)}", true);
        AddCell("Uwagi:", false);
        AddCell($"{request.Invoice.Remarks}", true);
            
        document.Add(summaryTable);
    
        string PreparePaymentDivided(bool isDivided)
        {
            return isDivided ? "TAK" : "NIE";
        }
            
        string PrepareAccountNumber(string number)
        {
            if (number == null) throw new ArgumentNullException(nameof(number));
            number = request.Invoice.AccountNumber.Value!.Trim();
            number = number.Replace(" ", string.Empty);
            return Regex.Replace(number, @"(\w{2})(\w{4})(\w{4})(\w{4})(\w{4})(\w{4})(\w{4})", @"$1 $2 $3 $4 $5 $6 $7");
        }
            
        void AddCell(string value, bool isLongCell, int fontSize = 8, bool isBold = false)
        {
            var cell = new Cell(1,isLongCell ? 3 : 1).Add(new Paragraph(value).SetFont(isBold ? helveticaBold : helvetica).SetFontSize(fontSize)).SetVerticalAlignment(VerticalAlignment.MIDDLE);
            cell.SetBorder(Border.NO_BORDER);
            summaryTable.AddCell(cell);
        }
    }
}