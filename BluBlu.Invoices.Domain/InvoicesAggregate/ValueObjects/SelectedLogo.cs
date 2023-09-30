using BluBlu.Common.Domain.ValueObjects.Serializers;
using BluBlu.Common.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<SelectedLogo>))]
public class SelectedLogo : StringValueObject
{
    public SelectedLogo()
    {
    }

    public SelectedLogo(string value) : base(value, 100)
    {
    }
}
