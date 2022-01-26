using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<PriceNet>))]
public class PriceNet : DecimalValueObject
{
    private static readonly int Precision = 2;

    public PriceNet() : base(Precision)
    {
    }

    public PriceNet(decimal value, decimal? minValue = 0m, decimal? maxValue = 99999999999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
}