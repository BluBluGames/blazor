using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<InvoiceNumber>))]
public class InvoiceNumber : StringValueObject
{
    public InvoiceNumber()
    {
    }

    public InvoiceNumber(string value) : base(value, 250)
    {
    }
}