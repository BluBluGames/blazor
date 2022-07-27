using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.StockEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<PBV>))]
public class PBV : DecimalValueObject
{
    private static readonly int Precision = 2;

    public PBV() : base(Precision)
    {
    }

    public PBV(decimal value) : base(value, Precision)
    {
    }

    public PBV(decimal value, decimal? minValue = 0m, decimal? maxValue = 999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
}