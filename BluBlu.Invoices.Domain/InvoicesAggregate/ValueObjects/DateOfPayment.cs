using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoDateTimeValueObjectSerializer<DateOfPayment>))]
public class DateOfPayment : DateTimeValueObject
{
    public DateOfPayment()
    {
    }

    public DateOfPayment(DateTime value) : base(value)
    {
    }
}