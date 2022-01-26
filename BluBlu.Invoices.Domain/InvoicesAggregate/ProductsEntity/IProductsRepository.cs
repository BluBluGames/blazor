using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;

namespace BluBlu.Invoices.Domain.ProductsEntity;

public interface IProductsRepository
{
    Task<Product> CreateProduct(Product invoice);
}