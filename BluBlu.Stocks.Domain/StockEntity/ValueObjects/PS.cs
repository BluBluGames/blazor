using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.StockEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<PS>))]
public class PS : DecimalValueObject
{
    private static readonly int Precision = 2;

    public PS() : base(Precision)
    {
    }

    public PS(decimal value) : base(value, Precision)
    {
    }

    public PS(decimal value, decimal? minValue = 0m, decimal? maxValue = 999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
}