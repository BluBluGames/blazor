using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                result.SumNet = Math.Round(result.SumNet + product.Product.PriceNet.Value * product.NumberOfUnits.Value, 2);
                result.SumVat = Math.Round(result.SumVat + product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2);
                result.SumGross = Math.Round(
                    result.SumGross + product.Product.PriceNet.Value * product.NumberOfUnits.Value +
                    product.Product.PriceNet.Value * product.NumberOfUnits.Value * product.Product.Vat.Value / 100, 2);

                var isVatZw = product.Product.Vat.Value switch
                {
                    0 => product.Product.IsVatZw.Value ? "zw" : "0",
                    _ => product.Product.Vat.Value.ToString(CultureInfo.InvariantCulture)
                };

                if (result.SumByVat.ContainsKey(isVatZw))
                {
                    var (_, value) = result.SumByVat.Single(s =>
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
                    result.SumByVat.Add(isVatZw, new PriceByVat
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

            return result;
        }
    }
}
