using MediatR;
using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Delete
{
    public class DeleteInvoiceCommand : IRequest<DeleteResult>
    {
        public string Id { get; set; } = null!;
    }
}