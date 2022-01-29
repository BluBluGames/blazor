using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Country>))]
public class Country : StringValueObject
{
    public Country()
    {
    }

    public Country(string value) : base(value, 250)
    {
    }
}