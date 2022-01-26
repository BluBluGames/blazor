namespace BluBlu.Invoices.Domain.ContractorsEntity;

public interface IContractorsRepository
{
    Task<Contractor> CreateContractor(Contractor invoice);
}