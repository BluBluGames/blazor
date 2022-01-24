namespace BluBlu.Invoices.Infrastructure.Connection;

public class InvoicesOptions
{
    public string InvoicesCollectionName { get; set; } = null!;
    public string ContractorsCollectionName { get; set; } = null!;
    public string ConnectionString { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}