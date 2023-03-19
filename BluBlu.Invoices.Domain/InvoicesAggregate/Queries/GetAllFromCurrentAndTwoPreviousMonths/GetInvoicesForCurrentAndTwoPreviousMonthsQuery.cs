using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentAndTwoPreviousMonths;

public class GetInvoicesForCurrentAndTwoPreviousMonthsQuery : IRequest<List<Invoice>>
{
    public DateOnly CurrentDate { get; set; }
}