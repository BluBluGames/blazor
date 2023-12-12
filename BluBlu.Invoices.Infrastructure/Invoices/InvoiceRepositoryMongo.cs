using BluBlu.Invoices.Domain.InvoicesAggregate;
using BluBlu.Invoices.Infrastructure.Connection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BluBlu.Invoices.Infrastructure.Invoices;

public class InvoiceRepositoryMongo : IInvoiceRepositoryMongo
{
    private readonly IInvoicesDatabaseMongo _database;

    public InvoiceRepositoryMongo(IInvoicesDatabaseMongo database)
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

        return await _database.Invoices.Find(idFilter).FirstOrDefaultAsync();
    }

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

    public async Task<List<Invoice>> FetchInvoicesForCurrentAndTwoPreviousMonths(DateOnly currentDate)
    {
        var currentYear = currentDate.Year;
        var currentMonth = currentDate.Month;

        // Calculate the year and month for the previous two months, accounting for January
        var previousYear = currentYear;
        var previousMonth = currentMonth - 2;
        
        if (previousMonth < 1)
        {
            previousMonth += 12;
            previousYear -= 1;
        }

        // Construct filters for the current and previous two months
        var currentMonthFilter = Builders<Invoice>.Filter.Regex(i => i.InvoiceNumber, new BsonRegularExpression($"{currentMonth}-{currentYear}"));
        var previousMonthFilter = Builders<Invoice>.Filter.Regex(i => i.InvoiceNumber, new BsonRegularExpression($"{previousMonth}-{previousYear}"));
        var twoMonthsAgoFilter = Builders<Invoice>.Filter.Regex(i => i.InvoiceNumber, new BsonRegularExpression($"{previousMonth + 1}-{previousYear}"));

        // Combine the filters using a logical OR operator
        var combinedFilter = Builders<Invoice>.Filter.Or(currentMonthFilter, previousMonthFilter, twoMonthsAgoFilter);

        // Fetch the invoices matching the combined filter
        return await (await _database.Invoices.FindAsync(combinedFilter)).ToListAsync();
    }

    public async Task<List<Invoice>> FetchInvoicesForCurrentMonth(DateOnly requestCurrentDate)
    {
        var currentYear = requestCurrentDate.Year;
        var currentMonth = requestCurrentDate.Month;

        // Construct filter for the current month
        var currentMonthFilter = Builders<Invoice>.Filter.Regex(i => i.InvoiceNumber, new BsonRegularExpression($"{currentMonth}-{currentYear}"));

        // Fetch the invoices matching the current month filter
        return await (await _database.Invoices.FindAsync(currentMonthFilter)).ToListAsync();
    }

    public async Task<List<Invoice>> FetchInvoicesForPreviousMonth(DateOnly requestCurrentDate)
    {
        var previousMonth = requestCurrentDate.AddMonths(-1);
        var year = previousMonth.Year;
        var month = previousMonth.Month;

        // Construct filter for the previous month
        var previousMonthFilter = Builders<Invoice>.Filter.Regex(i => i.InvoiceNumber, new BsonRegularExpression($"{month:00}-{year}"));

        // Fetch the invoices matching the previous month filter
        return await (await _database.Invoices.FindAsync(previousMonthFilter)).ToListAsync();
    }
}