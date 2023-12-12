using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetById
{
    public class GetInvoiceByIdQueryHandler : IRequestHandler<GetInvoiceByIdQuery, Invoice>
    {
        private readonly IInvoiceRepositoryMongo _invoiceRepository;

        public GetInvoiceByIdQueryHandler(IInvoiceRepositoryMongo invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> Handle(GetInvoiceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.FetchInvoiceById(request.Id);
        }
    }
}