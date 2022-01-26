using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetByInvoiceNumber
{
    public class GetInvoicesByYearAndMonthQuery : IRequest<List<Invoice>>
    {
        public string Month { get; set; } = null!;
        public string Year { get; set; } = null!;
    }
}