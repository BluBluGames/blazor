using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Queries.GetById
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, Invoice>
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public GetByIdQueryHandler(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            return await _invoiceRepository.FetchById(request.Id);
        }
    }
}