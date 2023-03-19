using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromPreviousMonth;

public class GetInvoicesFromPreviousMonthQuery : IRequest<List<Invoice>>
{
    public DateOnly CurrentDate { get; set; }
}