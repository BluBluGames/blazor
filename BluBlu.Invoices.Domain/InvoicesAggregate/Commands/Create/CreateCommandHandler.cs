using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, Invoice>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public CreateCommandHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public async Task<Invoice> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        return await _invoiceRepository.Create(request.Invoice);
    }
}