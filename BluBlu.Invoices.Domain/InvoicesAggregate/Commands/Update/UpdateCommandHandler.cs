using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Update
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand, Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public UpdateCommandHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.Update(request.Id, request.Invoice);
        }
    }
}