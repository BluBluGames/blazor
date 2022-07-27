using BluBlu.Stocks.Domain.CountryExchangeEntity;
using BluBlu.Stocks.Domain.StockEntity;
using MongoDB.Driver;

namespace BluBlu.Stocks.Infrastructure.Connection;

public interface IStocksDatabase
{
    IMongoCollection<Stock> Stocks { get; set; }
    IMongoCollection<CountryExchange> CountriesExchanges { get; set; }
}