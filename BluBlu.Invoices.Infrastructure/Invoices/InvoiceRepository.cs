﻿using BluBlu.Invoices.Domain.InvoicesAggregate;
using BluBlu.Invoices.Infrastructure.Connection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Invoices;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IInvoicesDatabase _database;

    public InvoiceRepository(IInvoicesDatabase database)
    {
        _database = database;
    }
    
    public async Task<List<Invoice>> FetchInvoicesAll()
    {
        return await _database.Invoices.Find(Builders<Invoice>.Filter.Empty).ToListAsync();
    }

    public async Task<Invoice> FetchInvoiceById(string id)
    {
        var idFilter = Builders<Invoice>.Filter.Eq(i => i.Id, id);

        return await _database.Invoices.Find(idFilter).FirstOrDefaultAsync();    }

    public async Task<List<Invoice>> FetchInvoiceByYearAndMonth(string year, string month)
    {
        var filter = Builders<Invoice>.Filter.Regex(i => i.InvoiceNumber, new BsonRegularExpression($"{month}-{year}"));
            
        return await (await _database.Invoices.FindAsync(filter)).ToListAsync();
    }

    public async Task<Invoice> CreateInvoice(Invoice invoice)
    {
        invoice.Id = ObjectId.GenerateNewId().ToString();
        await _database.Invoices.InsertOneAsync(invoice);
        var idFilter = Builders<Invoice>.Filter.Eq(i => i.Id, invoice.Id);
        
        return await _database.Invoices.Find(idFilter).FirstOrDefaultAsync();
    }

    public async Task<Invoice> UpdateInvoice(string id, Invoice invoice)
    {
        var idFilter = Builders<Invoice>.Filter.Eq(i => i.Id, id);
        invoice.Id = id;

        return await _database.Invoices.FindOneAndReplaceAsync(idFilter, invoice);
    }

    public async Task<DeleteResult> DeleteInvoice(string id)
    {
        return await _database.Invoices.DeleteOneAsync(i => i.Id == id);
    }
}