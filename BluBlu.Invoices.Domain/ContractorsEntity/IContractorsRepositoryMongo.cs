namespace BluBlu.Invoices.Domain.ContractorsEntity;

public interface IContractorsRepositoryMongo
{
    Task<Contractor> CreateContractor(Contractor invoice);
}