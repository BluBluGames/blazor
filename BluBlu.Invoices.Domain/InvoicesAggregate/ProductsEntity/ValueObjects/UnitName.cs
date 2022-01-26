using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Name>))]
public class UnitName : StringValueObject
{
    protected UnitName()
    {
    }

    public UnitName(string value) : base(value, 250)
    {
    }
}