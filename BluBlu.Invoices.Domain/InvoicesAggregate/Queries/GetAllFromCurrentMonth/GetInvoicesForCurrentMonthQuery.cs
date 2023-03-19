using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAllFromCurrentMonth;

public class GetInvoicesForCurrentMonthQuery : IRequest<List<Invoice>>
{
    public DateOnly CurrentDate { get; set; }
}