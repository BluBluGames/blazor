using MediatR;

namespace BluBlu.Invoices.Domain.Invoices.Queries.GetByInvoiceNumber
{
    public class GetByInvoicesYearAndMonthQuery : IRequest<List<Invoice>>
    {
        public string Month { get; set; }
        public string Year { get; set; }
    }
}