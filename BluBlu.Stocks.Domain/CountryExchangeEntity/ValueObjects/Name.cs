using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<Name>))]
public class Name : StringValueObject
{
    public Name()
    {
    }

    public Name(string value) : base(value, 250)
    {
    }
}