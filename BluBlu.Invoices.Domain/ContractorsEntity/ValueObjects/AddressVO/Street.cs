using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Street>))]
public class Street : StringValueObject
{
    public Street()
    {
    }

    public Street(string value) : base(value, 250)
    {
    }
}