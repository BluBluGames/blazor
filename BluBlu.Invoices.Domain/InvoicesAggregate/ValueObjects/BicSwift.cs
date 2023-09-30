using BluBlu.Common.Domain.ValueObjects.Serializers;
using BluBlu.Common.Domain.ValueObjects;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<BicSwift>))]
public class BicSwift : StringValueObject
{
    public BicSwift()
    {
    }

    public BicSwift(string value) : base(value, 20)
    {
    }
}
