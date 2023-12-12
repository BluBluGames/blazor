using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;

namespace BluBlu.Invoices.Domain.ProductsEntity;

public interface IProductsRepositoryMongo
{
    Task<Product> CreateProduct(Product invoice);
}