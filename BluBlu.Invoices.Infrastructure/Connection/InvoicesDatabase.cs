using BluBlu.Invoices.Domain.Invoices;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Connection;

public class InvoicesDatabase : IInvoicesDatabase
{
    public InvoicesDatabase(IOptions<InvoicesOptions> options)
    {
        IMongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
        var database = mongoClient.GetDatabase(options.Value.DatabaseName);
        Invoices = database.GetCollection<Invoice>(options.Value.InvoicesCollectionName);
    }

    public IMongoCollection<Invoice> Invoices { get; set; }   
}