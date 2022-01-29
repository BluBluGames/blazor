using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects.ProductVO;

[BsonSerializer(typeof(MongoDecimalValueObjectSerializer<NumberOfUnits>))]
public class NumberOfUnits : DecimalValueObject
{
    private static readonly int Precision = 2;

    public NumberOfUnits() : base(Precision)
    {
    }

    public NumberOfUnits(decimal value) : base(value, Precision)
    {
    }
    
    public NumberOfUnits(decimal value, decimal? minValue = 0m, decimal? maxValue = 99999999999.99m)
        : base(value, Precision, minValue, maxValue)
    {
    }
}