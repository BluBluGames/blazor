using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<PostCity>))]
public class PostCity : StringValueObject
{
    public PostCity()
    {
    }

    public PostCity(string value) : base(value, 250)
    {
    }
}