using BluBlu.Invoices.Domain.Invoices;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Connection;

public interface IInvoicesDatabase
{
    IMongoCollection<Invoice> Invoices { get; set; }
}