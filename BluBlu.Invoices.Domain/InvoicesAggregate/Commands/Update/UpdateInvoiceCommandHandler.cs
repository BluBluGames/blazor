using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Update
{
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public UpdateInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.UpdateInvoice(request.Id, request.Invoice);
        }
    }
}