using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoBooleanValueObjectSerializer<IsPaymentDivided>))]
public class IsPaymentDivided : BooleanValueObject
{
    public IsPaymentDivided()
    {
    }

    public IsPaymentDivided(bool value) : base(value)
    {
    }
}