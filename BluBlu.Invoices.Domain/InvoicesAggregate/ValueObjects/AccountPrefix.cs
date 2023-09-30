using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<AccountPrefix>))]
public class AccountPrefix : StringValueObject
{
    public AccountPrefix()
    {
    }

    public AccountPrefix(string value) : base(value, 2, 2)
    {
    }
}