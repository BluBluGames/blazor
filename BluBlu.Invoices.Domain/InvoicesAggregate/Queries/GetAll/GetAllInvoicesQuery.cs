using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAll;

public class GetAllInvoicesQuery : IRequest<List<Invoice>>
{
    
}