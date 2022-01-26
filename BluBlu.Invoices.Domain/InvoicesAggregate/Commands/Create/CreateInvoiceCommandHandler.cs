using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Create;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public CreateInvoiceCommandHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        return await _invoiceRepository.CreateInvoice(request.Invoice);
    }
}