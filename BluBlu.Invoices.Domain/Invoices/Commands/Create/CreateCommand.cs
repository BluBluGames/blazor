using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Commands.Create;

public class CreateCommand : IRequest<Invoice>
{
    public Invoice Invoice { get; set; }
}