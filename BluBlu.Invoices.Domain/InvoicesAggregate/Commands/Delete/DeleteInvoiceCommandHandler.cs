using MediatR;
using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Delete
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, DeleteResult>
    {
        private readonly IInvoiceRepositoryMongo _invoiceRepository;

        public DeleteInvoiceCommandHandler(IInvoiceRepositoryMongo invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<DeleteResult> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.DeleteInvoice(request.Id);
        }
    }
}