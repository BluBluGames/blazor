using MediatR;
using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Delete
{
    public class DeleteInvoiceCommandHandler : IRequestHandler<DeleteInvoiceCommand, DeleteResult>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public DeleteInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<DeleteResult> Handle(DeleteInvoiceCommand request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.DeleteInvoice(request.Id);
        }
    }
}