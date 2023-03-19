using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentAndTwoPreviousMonths;

public class GetInvoicesForCurrentAndTwoPreviousMonthsQueryHandler : IRequestHandler<GetInvoicesForCurrentAndTwoPreviousMonthsQuery, List<Invoice>>
{
    private readonly IInvoiceRepository _invoicesRepository;

    public GetInvoicesForCurrentAndTwoPreviousMonthsQueryHandler(IInvoiceRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetInvoicesForCurrentAndTwoPreviousMonthsQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchInvoicesForCurrentAndTwoPreviousMonths(request.CurrentDate);
    }
}