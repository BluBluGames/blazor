using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Create;

public class CreateInvoiceCommand : IRequest<Invoice>
{
    public Invoice Invoice { get; set; } = null!;
}