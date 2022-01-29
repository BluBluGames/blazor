using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<PostCode>))]
public class PostCode : StringValueObject
{
    public PostCode()
    {
    }

    public PostCode(string value) : base(value, 250)
    {
    }
}