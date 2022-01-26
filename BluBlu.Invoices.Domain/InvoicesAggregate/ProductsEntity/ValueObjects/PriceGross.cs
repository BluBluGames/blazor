using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<PriceGross>))]
public class PriceGross : DecimalValueObject
{
    private static readonly int Precision = 2;
    
    public PriceGross() : base(Precision)
    {
    }

    public PriceGross(decimal value, decimal? minValue = 0m, decimal? maxValue = 99999999999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
    
    public override string ToString() => Value.ToString("0.00").Replace('.', ',');
}