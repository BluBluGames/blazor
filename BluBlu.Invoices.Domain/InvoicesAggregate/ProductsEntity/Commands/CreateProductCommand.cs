using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.Commands;

public class CreateProductCommand : IRequest<Product>
{
    public Product Product { get; set; } = null!;
}