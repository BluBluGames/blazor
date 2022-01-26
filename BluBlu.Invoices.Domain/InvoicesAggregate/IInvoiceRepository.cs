using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.InvoicesAggregate;

public interface IInvoiceRepository
{
    Task<List<Invoice>> FetchInvoicesAll();
    Task<Invoice> FetchInvoiceById(string id);
    Task<List<Invoice>> FetchInvoiceByYearAndMonth(string year, string month);
    Task<Invoice> CreateInvoice(Invoice invoice);
    Task<Invoice> UpdateInvoice(string id, Invoice invoice);
    Task<DeleteResult> DeleteInvoice(string id);
}