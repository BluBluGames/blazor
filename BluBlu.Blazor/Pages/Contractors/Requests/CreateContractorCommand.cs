namespace BluBlu.Blazor.Pages.Contractors.Requests;

public class CreateContractorCommand
{
    public string Name { get; set; } = null!;
    public string AddressStreet { get; set; } = null!;
    public string AddressPostCity { get; set; } = null!;
    public string AddressCountry { get; set; } = null!;
    public string AddressPostCode { get; set; } = null!;
    public string AddressBuildingNumber { get; set; } = null!;
    public string AddressFlatNumber { get; set; } = null!;
    public string Nip { get; set; } = null!;

    public BluBlu.Invoices.Domain.ContractorsEntity.Contractor ToDomainModel()
        => new(
            new(Name),
            new(
                new(AddressStreet),
                new(AddressPostCity),
                new(AddressCountry),
                new(AddressPostCode),
                new(AddressBuildingNumber),
                new(AddressFlatNumber)),
            new(Nip));
}