namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects
{
    public class PriceByVat
    {
        public decimal NetPrice { get; set; }
        public decimal VatPrice { get; set; }
        public decimal GrossPrice { get; set; }
        public bool IsVatZw { get; set; }
    }
}