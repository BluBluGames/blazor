using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Commands.Create;

public class CreateCommandHandler : IRequestHandler<CreateCommand, Invoice>
{
    private readonly IInvoiceRepository _invoiceRepository;

    public CreateCommandHandler(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    public Task<Invoice> Handle(CreateCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}