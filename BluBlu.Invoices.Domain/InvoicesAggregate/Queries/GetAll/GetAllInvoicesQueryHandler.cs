using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAll;

public class GetAllInvoicesQueryHandler : IRequestHandler<GetAllInvoicesQuery, List<Invoice>>
{
    private readonly IInvoiceRepository _invoicesRepository;

    public GetAllInvoicesQueryHandler(IInvoiceRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetAllInvoicesQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchInvoicesAll();
    }
}