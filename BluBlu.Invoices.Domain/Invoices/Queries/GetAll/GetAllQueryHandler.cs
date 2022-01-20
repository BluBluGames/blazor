using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Queries.GetAll;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, List<Invoice>>
{
    private readonly IInvoiceRepository _invoicesRepository;

    public GetAllQueryHandler(IInvoiceRepository invoicesRepository)
    {
        _invoicesRepository = invoicesRepository;
    }

    public async Task<List<Invoice>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _invoicesRepository.FetchAll();
    }
}