namespace BluBlu.Invoices.Domain.ContractorsEntity;

public interface IContractorsRepository
{
    Task<Contractor> Create(Contractor invoice);
}