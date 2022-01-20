using MediatR;
using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.Invoices.Commands.Delete
{
    public class DeleteCommand : IRequest<DeleteResult>
    {
        public string Id { get; set; }
    }
}