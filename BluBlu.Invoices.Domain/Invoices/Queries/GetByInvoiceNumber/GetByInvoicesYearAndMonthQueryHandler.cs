using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Queries.GetByInvoiceNumber
{
    public class GetByInvoicesYearAndMonthQueryHandler : IRequestHandler<GetByInvoicesYearAndMonthQuery,  List<Invoice>>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetByInvoicesYearAndMonthQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<Invoice>> Handle(GetByInvoicesYearAndMonthQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.FetchByInvoiceYearAndMonth(request.Month, request.Year);
        }
    }
}