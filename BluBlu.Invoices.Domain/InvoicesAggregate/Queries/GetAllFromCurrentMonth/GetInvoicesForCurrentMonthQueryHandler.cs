using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentMonth;

public class GetInvoicesForCurrentMonthQueryHandler : IRequestHandler<GetInvoicesForCurrentMonthQuery, List<Invoice>>
{
    private readonly IInvoiceRepository _invoicesRepository;

    public GetInvoicesForCurrentMonthQueryHandler(IInvoiceRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetInvoicesForCurrentMonthQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchInvoicesForCurrentMonth(request.CurrentDate);
    }
}