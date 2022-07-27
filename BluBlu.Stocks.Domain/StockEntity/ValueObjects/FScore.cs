using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.StockEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<FScore>))]
public class FScore : DecimalValueObject
{
    private static readonly int Precision = 2;

    public FScore() : base(Precision)
    {
    }

    public FScore(decimal value) : base(value, Precision)
    {
    }

    public FScore(decimal value, decimal? minValue = 0m, decimal? maxValue = 999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
}