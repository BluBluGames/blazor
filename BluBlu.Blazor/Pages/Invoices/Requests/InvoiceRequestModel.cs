using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects;
using BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;
using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects.ProductVO;
using Name = BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.Name;

namespace BluBlu.Blazor.Pages.Invoices.Requests;

public class InvoiceRequestModel
{
    public string InvoiceNumber { get; set; } = null!;
    public DateTime DateOfInvoice { get; set; }
    public DateTime DateOfRelease { get; set; }
    public DateTime DateOfPayment { get; set; }
    public string FormOfPayment { get; set; } = null!;
    public string AccountNumber { get; set; } = null!;
    public bool IsPaymentDivided { get; set; }
    public bool IsPaid { get; set; }
    public string Remarks { get; set; } = null!;
    public ContractorRequestModel Seller { get; set; } = null!;
    public ContractorRequestModel Buyer { get; set; } = null!;
    public ICollection<ProductRequestModel> Products { get; set; } = null!;
    
    public BluBlu.Invoices.Domain.InvoicesAggregate.Invoice ToDomainModel()
    {
        return new(
            new(InvoiceNumber),
            new(DateOfInvoice),
            new(DateOfRelease),
            new(DateOfPayment),
            new(FormOfPayment),
            new(AccountNumber),
            new(IsPaymentDivided),
            new(IsPaid),
            string.IsNullOrWhiteSpace(Remarks) ? null : new(Remarks),
            new(
                new(Seller.Name),
                new(
                    new(Seller.AddressStreet),
                    new(Seller.AddressPostCity),
                    new(Seller.AddressCountry),
                    new(Seller.AddressPostCode),
                    new(Seller.AddressBuildingNumber),
                    string.IsNullOrWhiteSpace(Seller.AddressFlatNumber) ? null : new(Seller.AddressFlatNumber)),
                string.IsNullOrWhiteSpace(Seller.Nip) ? null : new(Seller.Nip)),
            new(
                new(Buyer.Name),
                new(
                    new(Buyer.AddressStreet),
                    new(Buyer.AddressPostCity),
                    new(Buyer.AddressCountry),
                    new(Buyer.AddressPostCode),
                    new(Buyer.AddressBuildingNumber),
                    string.IsNullOrWhiteSpace(Buyer.AddressFlatNumber) ? null : new(Buyer.AddressFlatNumber)),
                string.IsNullOrWhiteSpace(Buyer.Nip) ? null : new(Buyer.Nip)),
            Products.Select(product => new ProductWithNumberOfUnits(
                    new(
                        new(product.Name),
                        new(product.PriceNet),
                        new(product.UnitName),
                        new(product.Vat),
                        new(product.IsVatZw),
                        new(product.PriceGross),
                        string.IsNullOrWhiteSpace(product.LegalBasisForTaxExemption) ? null : new(product.LegalBasisForTaxExemption)), 
                    new(product.NumberOfUnits)))
                .ToList());
    }
}