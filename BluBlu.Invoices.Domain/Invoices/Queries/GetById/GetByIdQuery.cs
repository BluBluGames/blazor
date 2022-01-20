using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Queries.GetById
{
    public class GetByIdQuery : IRequest<Invoice>
    {
        public string Id { get; set; }
    }
}