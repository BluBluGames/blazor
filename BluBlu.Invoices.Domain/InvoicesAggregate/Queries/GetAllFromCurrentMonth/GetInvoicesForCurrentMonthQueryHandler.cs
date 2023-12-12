using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentMonth;

public class GetInvoicesForCurrentMonthQueryHandler : IRequestHandler<GetInvoicesForCurrentMonthQuery, List<Invoice>>
{
    private readonly IInvoiceRepositoryMongo _invoicesRepository;

    public GetInvoicesForCurrentMonthQueryHandler(IInvoiceRepositoryMongo invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetInvoicesForCurrentMonthQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchInvoicesForCurrentMonth(request.CurrentDate);
    }
}