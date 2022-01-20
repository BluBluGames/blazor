namespace BluBlu.Invoices.Domain.Invoices.ValueObjects
{
    public class PriceByVat
    {
        public double NetPrice { get; set; }
        public double VatPrice { get; set; }
        public double GrossPrice { get; set; }
        public bool IsVatZw { get; set; }
    }
}