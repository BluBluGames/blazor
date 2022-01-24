using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<BuildingNumber>))]
public class BuildingNumber : StringValueObject
{
    protected BuildingNumber()
    {
    }

    public BuildingNumber(string value) : base(value, 250)
    {
    }
}