using MongoDB.Driver;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity;

public interface ICountryExchangeRepository
{
    Task<List<CountryExchange>> FetchCountriesAll();
    Task<CountryExchange> FetchCountryById(string id);
    Task<CountryExchange> CreateCountry(CountryExchange invoice);
    Task<CountryExchange> UpdateCountry(string id, CountryExchange invoice);
    Task<DeleteResult> DeleteCountry(string id);
}