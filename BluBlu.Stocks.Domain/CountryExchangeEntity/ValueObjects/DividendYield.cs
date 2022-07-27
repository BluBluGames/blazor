using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<DividendYield>))]
public class DividendYield : DecimalValueObject
{
    private static readonly int Precision = 2;

    public DividendYield() : base(Precision)
    {
    }

    public DividendYield(decimal value) : base(value, Precision)
    {
    }

    public DividendYield(decimal value, decimal? minValue = 0m, decimal? maxValue = 999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
}