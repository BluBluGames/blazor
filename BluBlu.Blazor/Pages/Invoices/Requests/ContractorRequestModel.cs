namespace BluBlu.Blazor.Pages.Invoices.Requests;

public class ContractorRequestModel
{
    public string Name { get; set; } = null!;
    public string AddressStreet { get; set; } = null!;
    public string AddressPostCity { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string AddressPostCode { get; set; } = null!;
    public string AddressBuildingNumber { get; set; } = null!;
    public string AddressFlatNumber { get; set; } = null!;
    public string Nip { get; set; } = null!;
    public string NipPrefix { get; set; } = null!;
}