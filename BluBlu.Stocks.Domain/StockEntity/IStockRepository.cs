using MongoDB.Driver;

namespace BluBlu.Stocks.Domain.StockEntity;

public interface IStockRepository
{
    Task<List<Stock>> FetchStocksAll();
    Task<Stock> FetchStockById(string id);
    Task<Stock> CreateStock(Stock invoice);
    Task<Stock> UpdateStock(string id, Stock invoice);
    Task<DeleteResult> DeleteStock(string id);
}