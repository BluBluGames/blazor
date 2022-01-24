using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetById
{
    public class GetByIdQuery : IRequest<Invoice>
    {
        public string Id { get; set; } = null!;
    }
}