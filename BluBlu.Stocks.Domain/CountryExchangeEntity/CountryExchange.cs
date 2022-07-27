using BluBlu.Stocks.Domain.CountryExchangeEntity.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity;

public class CountryExchange
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; } = null!;
    [BsonElement("Country")] public Country Country { get; set; } = null!;
    [BsonElement("Year")] public Year Year { get; set; } = null!;
    [BsonElement("PE")] public PE PE { get; set; } = null!;
    [BsonElement("CAPE")] public CAPE CAPE { get; set; } = null!;
    [BsonElement("PBV")] public PBV PBV { get; set; } = null!;
    [BsonElement("DividendYield")] public DividendYield DividendYield { get; set; } = null!;
    [BsonElement("Year")] public Year YearOfCalculation { get; set; } = null!;
    
    public CountryExchange(Country country, Year yearOfCalculation, PE pe, CAPE cape, PBV pbv, DividendYield dividendYield)
    {
        Country = country;
        YearOfCalculation = yearOfCalculation;
        PE = pe;
        CAPE = cape;
        PBV = pbv;
        DividendYield = dividendYield;
    }
}