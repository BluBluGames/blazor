using MediatR;
using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Delete
{
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand, DeleteResult>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public DeleteCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<DeleteResult> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.Delete(request.Id);
        }
    }
}