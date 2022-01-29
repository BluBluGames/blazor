using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoBooleanValueObjectSerializer<IsPaid>))]
public class IsPaid : BooleanValueObject
{
    public IsPaid()
    {
    }

    public IsPaid(bool value) : base(value)
    {
    }
}