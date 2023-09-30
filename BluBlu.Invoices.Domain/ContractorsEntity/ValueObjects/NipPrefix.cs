using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<NipPrefix>))]
public class NipPrefix : StringValueObject
{
    public NipPrefix()
    {
    }

    public NipPrefix(string value) : base(value, 2, 2)
    { 
    }
}