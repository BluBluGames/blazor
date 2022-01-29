using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoDateTimeValueObjectSerializer<DateOfInvoice>))]
public class DateOfInvoice : DateTimeValueObject
{
    public DateOfInvoice()
    {
    }

    public DateOfInvoice(DateTime value) : base(value)
    {
    }
}