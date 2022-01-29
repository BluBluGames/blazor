using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoDateTimeValueObjectSerializer<DateOfRelease>))]
public class DateOfRelease : DateTimeValueObject
{
    public DateOfRelease()
    {
    }

    public DateOfRelease(DateTime value) : base(value)
    {
    }
}