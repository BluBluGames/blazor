using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate;
using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Connection;

public class InvoicesDatabaseMongo : IInvoicesDatabaseMongo
{
    public InvoicesDatabaseMongo(IOptions<InvoicesOptionsMongo> options)
    {
        // IMongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
        IMongoClient mongoClient = new MongoClient(options.Value.ConnectionStringDev);
        var database = mongoClient.GetDatabase(options.Value.DatabaseName);
        Invoices = database.GetCollection<Invoice>(options.Value.InvoicesCollectionName);
        Contractors = database.GetCollection<Contractor>(options.Value.ContractorsCollectionName);
        Products = database.GetCollection<Product>(options.Value.ContractorsCollectionName);
    }

    public IMongoCollection<Invoice> Invoices { get; set; }   
    public IMongoCollection<Contractor> Contractors { get; set; }   
    public IMongoCollection<Product> Products { get; set; }   
}