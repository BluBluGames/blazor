using BluBlu.Invoices.Domain.ContractorsEntity;
using BluBlu.Invoices.Domain.InvoicesAggregate;
using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Connection;

public interface IInvoicesDatabase
{
    IMongoCollection<Invoice> Invoices { get; set; }
    IMongoCollection<Contractor> Contractors { get; set; }
    IMongoCollection<Product> Products { get; set; }
}