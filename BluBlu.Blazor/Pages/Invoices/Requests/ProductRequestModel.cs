namespace BluBlu.Blazor.Pages.Invoices.Requests;

public class ProductRequestModel
{
    public string Name { get; set; } = null!;
    public decimal PriceNet { get; set; }
    public decimal NumberOfUnits { get; set; }
    public string UnitName { get; set; } = null!;
    public decimal Vat { get; set; }
    public bool IsVatZw { get; set; }
    public decimal PriceGross { get; set; }
    public string LegalBasisForTaxExemption { get; set; } = null!;
}