using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<FlatNumber>))]
public class FlatNumber : StringValueObject
{
    public FlatNumber()
    {
    }

    public FlatNumber(string value) : base(value, 250)
    {
    }
}