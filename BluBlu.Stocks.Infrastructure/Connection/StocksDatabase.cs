using BluBlu.Stocks.Domain.CountryExchangeEntity;
using BluBlu.Stocks.Domain.StockEntity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BluBlu.Stocks.Infrastructure.Connection;

public class StocksDatabase : IStocksDatabase
{
    public StocksDatabase(IOptions<StocksOptions> options)
    {
        try
        {
            // IMongoClient mongoClient = new MongoClient(options.Value.ConnectionString);
            IMongoClient mongoClient = new MongoClient(options.Value.ConnectionStringDev);
            var database = mongoClient.GetDatabase(options.Value.DatabaseName);
            Stocks = database.GetCollection<Stock>(options.Value.StocksCollectionName);
            CountriesExchanges = database.GetCollection<CountryExchange>(options.Value.CountriesExchangesCollectionName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IMongoCollection<Stock> Stocks { get; set; }
    public IMongoCollection<CountryExchange> CountriesExchanges { get; set; }
}