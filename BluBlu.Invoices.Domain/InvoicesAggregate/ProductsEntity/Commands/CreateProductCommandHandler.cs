using BluBlu.Invoices.Domain.ProductsEntity;
using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductsRepository _productsRepository;

    public CreateProductCommandHandler(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }
    
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productsRepository.CreateProduct(request.Product);
    }
}