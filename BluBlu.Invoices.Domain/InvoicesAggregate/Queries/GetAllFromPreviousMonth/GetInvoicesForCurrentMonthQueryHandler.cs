using BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentMonth;
using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromPreviousMonth;

public class GetInvoicesFromPreviousMonthQueryHandler : IRequestHandler<GetInvoicesFromPreviousMonthQuery, List<Invoice>>
{
    private readonly IInvoiceRepository _invoicesRepository;

    public GetInvoicesFromPreviousMonthQueryHandler(IInvoiceRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetInvoicesFromPreviousMonthQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchInvoicesForPreviousMonth(request.CurrentDate);
    }
}