using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetByInvoiceNumber
{
    public class GetInvoicesByYearAndMonthQueryHandler : IRequestHandler<GetInvoicesByYearAndMonthQuery,  List<Invoice>>
    {
        private readonly IInvoiceRepositoryMongo _invoiceRepository;

        public GetInvoicesByYearAndMonthQueryHandler(IInvoiceRepositoryMongo invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<List<Invoice>> Handle(GetInvoicesByYearAndMonthQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.FetchInvoiceByYearAndMonth(request.Month, request.Year);
        }
    }
}