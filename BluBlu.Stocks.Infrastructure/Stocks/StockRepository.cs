using BluBlu.Stocks.Domain.StockEntity;
using BluBlu.Stocks.Infrastructure.Connection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BluBlu.Stocks.Infrastructure.Stocks;

public class StockRepository : IStockRepository
{
    private readonly IStocksDatabase _database;

    public StockRepository(IStocksDatabase database)
    {
        _database = database;
    }

    public async Task<List<Stock>> FetchStocksAll()
    {
        return await _database.Stocks.Find(Builders<Stock>.Filter.Empty).ToListAsync();
    }

    public async Task<Stock> FetchStockById(string id)
    {
        var idFilter = Builders<Stock>.Filter.Eq(i => i.Id, id);

        return await _database.Stocks.Find(idFilter).FirstOrDefaultAsync();
    }

    public async Task<Stock> CreateStock(Stock stock)
    {
        stock.Id = ObjectId.GenerateNewId().ToString();
        await _database.Stocks.InsertOneAsync(stock);
        var idFilter = Builders<Stock>.Filter.Eq(i => i.Id, stock.Id);
        
        return await _database.Stocks.Find(idFilter).FirstOrDefaultAsync();
    }

    public async Task<Stock> UpdateStock(string id, Stock stock)
    {
        var idFilter = Builders<Stock>.Filter.Eq(i => i.Id, id);
        stock.Id = id;

        return await _database.Stocks.FindOneAndReplaceAsync(idFilter, stock);
    }

    public async Task<DeleteResult> DeleteStock(string id)
    {
        return await _database.Stocks.DeleteOneAsync(i => i.Id == id);
    }
}