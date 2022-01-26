using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetById
{
    public class GetInvoiceByIdQuery : IRequest<Invoice>
    {
        public string Id { get; set; } = null!;
    }
}