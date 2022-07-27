using BluBlu.Stocks.Domain.StockEntity.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.StockEntity;

public class Stock
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string Id { get; set; } = null!;
    [BsonElement("Country")] public Country Country { get; set; } = null!;
    [BsonElement("PE")] public PE PE { get; set; } = null!;
    [BsonElement("CAPE")] public CAPE CAPE { get; set; } = null!;
    [BsonElement("PS")] public PS PS { get; set; } = null!;
    [BsonElement("PBV")] public PBV PBV { get; set; } = null!;
    [BsonElement("FScore")] public FScore FScore { get; set; } = null!;
    [BsonElement("ROE")] public ROE ROE { get; set; } = null!;
    [BsonElement("DividendYield")] public DividendYield DividendYield { get; set; } = null!;
    [BsonElement("Sector")] public Sector Sector { get; set; } = null!;
    
    public Stock(Country country, PE pe, CAPE cape, PS ps, PBV pbv, FScore fScore, ROE roe, DividendYield dividendYield, Sector sector)
    {
        Country = country;
        PE = pe;
        CAPE = cape;
        PS = ps;
        PBV = pbv;
        FScore = fScore;
        ROE = roe;
        DividendYield = dividendYield;
        Sector = sector;
    }
}