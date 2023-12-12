using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentAndTwoPreviousMonths;

public class GetInvoicesForCurrentAndTwoPreviousMonthsQueryHandler : IRequestHandler<GetInvoicesForCurrentAndTwoPreviousMonthsQuery, List<Invoice>>
{
    private readonly IInvoiceRepositoryMongo _invoicesRepository;

    public GetInvoicesForCurrentAndTwoPreviousMonthsQueryHandler(IInvoiceRepositoryMongo invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetInvoicesForCurrentAndTwoPreviousMonthsQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchInvoicesForCurrentAndTwoPreviousMonths(request.CurrentDate);
    }
}