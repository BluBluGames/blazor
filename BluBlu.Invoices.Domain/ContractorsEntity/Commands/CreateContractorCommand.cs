using MediatR;

namespace BluBlu.Invoices.Domain.ContractorsEntity.Commands;

public class CreateContractorCommand : IRequest<Contractor>
{
    public Contractor Contractor { get; set; } = null!;
}