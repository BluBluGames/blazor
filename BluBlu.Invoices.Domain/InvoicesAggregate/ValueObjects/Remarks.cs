using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Remarks>))]
public class Remarks : StringValueObject
{
    public Remarks()
    {
    }

    public Remarks(string value) : base(value, 250)
    {
    }
}