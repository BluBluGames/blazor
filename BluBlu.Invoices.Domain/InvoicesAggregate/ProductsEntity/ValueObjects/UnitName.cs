using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<UnitName>))]
public class UnitName : StringValueObject
{
    public UnitName()
    {
    }

    public UnitName(string value) : base(value, 250)
    {
    }
}