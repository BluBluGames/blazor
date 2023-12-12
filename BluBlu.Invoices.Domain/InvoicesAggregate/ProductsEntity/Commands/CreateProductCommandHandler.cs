using BluBlu.Invoices.Domain.ProductsEntity;
using MediatR;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.Commands;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductsRepositoryMongo _productsRepository;

    public CreateProductCommandHandler(IProductsRepositoryMongo productsRepository)
    {
        _productsRepository = productsRepository;
    }
    
    public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        return await _productsRepository.CreateProduct(request.Product);
    }
}