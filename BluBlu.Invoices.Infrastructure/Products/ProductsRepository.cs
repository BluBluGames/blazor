using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using BluBlu.Invoices.Domain.ProductsEntity;
using BluBlu.Invoices.Infrastructure.Connection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Products;

public class ProductsRepository : IProductsRepository
{
    private readonly IInvoicesDatabase _database;

    public ProductsRepository(IInvoicesDatabase database)
    {
        _database = database;
    }

    public async Task<Product> CreateProduct(Product contractor)
    {
        contractor.Id = ObjectId.GenerateNewId().ToString();
        await _database.Products.InsertOneAsync(contractor);
        var idFilter = Builders<Product>.Filter.Eq(i => i.Id, contractor.Id);

        return await _database.Products.Find(idFilter).FirstOrDefaultAsync();
    }
}