using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.CreatePdf
{
    internal class InvoiceValuesCalculatorService
    {
        public InvoiceValuesResult CalculateValues(IEnumerable<ProductWithNumberOfUnits> products)
        {
            var result = new InvoiceValuesResult
            {
                SumNet = 0m,
                SumVat = 0m,
                SumGross = 0m,
                SumByVat = new SortedDictionary<string, PriceByVat>()
            };

            foreach (var product in products)
            {
                var totalNetPrice = product.Product.PriceNet.Value * product.NumberOfUnits.Value;
                var totalGrossPrice = product.Product.PriceGross.Value * product.NumberOfUnits.Value;
                var vatAmount = totalGrossPrice - totalNetPrice;

                result.SumNet += Math.Round(totalNetPrice, 2);
                result.SumGross += Math.Round(totalGrossPrice, 2);
                result.SumVat += Math.Round(vatAmount, 2);

                var isVatZw = product.Product.IsVatZw.Value ? "zw" : $"{product.Product.Vat.Value}%";

                if (result.SumByVat.ContainsKey(isVatZw))
                {
                    var priceByVat = result.SumByVat[isVatZw];
                    priceByVat.NetPrice += totalNetPrice;
                    priceByVat.VatPrice += vatAmount;
                    priceByVat.GrossPrice += totalGrossPrice;
                }
                else
                {
                    result.SumByVat.Add(isVatZw, new PriceByVat
                    {
                        NetPrice = totalNetPrice,
                        VatPrice = vatAmount,
                        GrossPrice = totalGrossPrice,
                        IsVatZw = product.Product.IsVatZw.Value
                    });
                }
            }

            // Rounding the totals
            result.SumNet = Math.Round(result.SumNet, 2);
            result.SumVat = Math.Round(result.SumVat, 2);
            result.SumGross = Math.Round(result.SumGross, 2);

            return result;
        }
    }
}
