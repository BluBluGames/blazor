using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<Vat>))]
public class Vat : DecimalValueObject
{
    private static readonly int Precision = 2;

    public Vat() : base(Precision)
    {
    }

    public Vat(decimal value) : base(value, Precision)
    {
    }

    public Vat(decimal value, decimal? minValue = 0m, decimal? maxValue = 999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
    
    public override string ToString() => Value.ToString("0.00").Replace('.', ',');
    public decimal GetDecimalValue() => Value / 100.00m;
}