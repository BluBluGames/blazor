using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Update
{
    public class UpdateInvoiceCommand : IRequest<Invoice>
    {
        public string Id { get; set; } = null!;
        public Invoice Invoice { get; set; } = null!;
    }
}