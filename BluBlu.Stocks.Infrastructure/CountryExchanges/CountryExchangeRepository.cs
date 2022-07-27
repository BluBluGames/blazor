using BluBlu.Stocks.Domain.CountryExchangeEntity;
using BluBlu.Stocks.Infrastructure.Connection;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BluBlu.Stocks.Infrastructure.CountryExchanges;

public class CountryExchangeRepository : ICountryExchangeRepository
{
    private readonly IStocksDatabase _database;
    
    public CountryExchangeRepository(IStocksDatabase database)
    {
        _database = database;
    }

    public async Task<List<CountryExchange>> FetchCountriesAll()
    {
        return await _database.CountriesExchanges.Find(Builders<CountryExchange>.Filter.Empty).ToListAsync();
    }

    public async Task<CountryExchange> FetchCountryById(string id)
    {
        var idFilter = Builders<CountryExchange>.Filter.Eq(i => i.Id, id);
        
        return await _database.CountriesExchanges.Find(idFilter).FirstOrDefaultAsync();
    }

    public async Task<CountryExchange> CreateCountry(CountryExchange countryExchange)
    {
        countryExchange.Id = ObjectId.GenerateNewId().ToString();
        await _database.CountriesExchanges.InsertOneAsync(countryExchange);
        var idFilter = Builders<CountryExchange>.Filter.Eq(i => i.Id, countryExchange.Id);
        
        return await _database.CountriesExchanges.Find(idFilter).FirstOrDefaultAsync();
    }

    public async Task<CountryExchange> UpdateCountry(string id, CountryExchange countryExchange)
    {
        var idFilter = Builders<CountryExchange>.Filter.Eq(i => i.Id, id);
        countryExchange.Id = id;
        
        return await _database.CountriesExchanges.FindOneAndReplaceAsync(idFilter, countryExchange);
    }

    public async Task<DeleteResult> DeleteCountry(string id)
    {
        return await _database.CountriesExchanges.DeleteOneAsync(i => i.Id == id);
    }
}