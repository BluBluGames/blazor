using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<FormOfPayment>))]
public class FormOfPayment : StringValueObject
{
    public FormOfPayment()
    {
    }

    public FormOfPayment(string value) : base(value, 250)
    {
    }
}