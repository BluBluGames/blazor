using BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

namespace BluBlu.Invoices.Domain;

internal class InvoiceValuesResult
{
    public decimal SumNet { get; set; }
    public decimal SumVat { get; set; }
    public decimal SumGross { get; set; }
    public SortedDictionary<string, PriceByVat> SumByVat { get; set; }
}
