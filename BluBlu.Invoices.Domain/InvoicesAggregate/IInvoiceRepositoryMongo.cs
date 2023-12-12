using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.InvoicesAggregate;

public interface IInvoiceRepositoryMongo
{
    Task<List<Invoice>> FetchInvoicesAll();
    Task<Invoice> FetchInvoiceById(string id);
    Task<List<Invoice>> FetchInvoiceByYearAndMonth(string year, string month);
    Task<Invoice> CreateInvoice(Invoice invoice);
    Task<Invoice> UpdateInvoice(string id, Invoice invoice);
    Task<DeleteResult> DeleteInvoice(string id);
    Task<List<Invoice>> FetchInvoicesForCurrentAndTwoPreviousMonths(DateOnly currentDate);
    Task<List<Invoice>> FetchInvoicesForCurrentMonth(DateOnly requestCurrentDate);
    Task<List<Invoice>> FetchInvoicesForPreviousMonth(DateOnly requestCurrentDate);
}