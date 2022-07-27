using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.ValueObjects;

[BsonSerializer(typeof(MongoDateTimeValueObjectSerializer<Year>))]
public class Year : DateTimeValueObject
{
    public Year()
    {
    }

    public Year(DateTime value) : base(value)
    {
    }
}