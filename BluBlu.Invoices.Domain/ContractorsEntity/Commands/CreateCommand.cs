using MediatR;

namespace BluBlu.Invoices.Domain.ContractorsEntity.Commands;

public class CreateCommand : IRequest<Contractor>
{
    public Contractor Contractor { get; set; } = null!;
}