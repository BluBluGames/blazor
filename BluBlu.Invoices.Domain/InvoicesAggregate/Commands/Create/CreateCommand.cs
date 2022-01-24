using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Create;

public class CreateCommand : IRequest<Invoice>
{
    public Invoice Invoice { get; set; } = null!;
}