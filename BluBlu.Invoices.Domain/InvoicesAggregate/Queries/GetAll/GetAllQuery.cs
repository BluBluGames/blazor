using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.Queries.GetAll;

public class GetAllQuery : IRequest<List<Invoice>>
{
    
}