using BluBlu.Common.Domain.ValueObjects.Serializers;
using BluBlu.Common.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<SelectedLanguage>))]
public class SelectedLanguage : StringValueObject
{
    public SelectedLanguage()
    {
    }

    public SelectedLanguage(string value) : base(value, 2)
    {
    }
}
