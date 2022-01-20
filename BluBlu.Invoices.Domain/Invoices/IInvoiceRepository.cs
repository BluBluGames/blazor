using MongoDB.Driver;

namespace BluBlu.Invoices.Domain.Invoices;

public interface IInvoiceRepository
{
    Task<List<Invoice>> FetchAll();
    Task<Invoice> FetchById(string id);
    Task<List<Invoice>> FetchByInvoiceYearAndMonth(string year, string month);
    Task<Invoice> Create(Invoice invoice);
    Task<Invoice> Update(string id, Invoice invoice);
    Task<DeleteResult> Delete(string id);
}