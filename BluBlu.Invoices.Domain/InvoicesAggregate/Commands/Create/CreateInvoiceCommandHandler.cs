using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Create;

public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Invoice>
{
    private readonly IInvoiceRepositoryMongo _invoiceRepository;

    public CreateInvoiceCommandHandler(IInvoiceRepositoryMongo invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Invoice> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
    {
        return await _invoiceRepository.CreateInvoice(request.Invoice);
    }
}