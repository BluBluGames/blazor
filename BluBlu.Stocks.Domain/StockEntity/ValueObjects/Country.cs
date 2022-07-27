using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using BluBlu.Stocks.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.StockEntity.ValueObjects;

[BsonSerializer(typeof(MongoEnumValueObjectSerializer<EnumValueObject<Enum>>))]
public class Country : EnumValueObject<CountryType>
{
    public Country(CountryType value) : base(value)
    {
    }

    protected Country()
    {
    }
}