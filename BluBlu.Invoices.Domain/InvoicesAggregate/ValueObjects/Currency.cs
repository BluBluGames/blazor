using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Currency>))]
public class Currency : StringValueObject
{
    public Currency()
    {
    }

    public Currency(string value) : base(value, 5)
    {
    }
}