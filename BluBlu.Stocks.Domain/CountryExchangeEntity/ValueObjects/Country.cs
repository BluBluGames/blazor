using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using BluBlu.Stocks.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.CountryExchangeEntity.ValueObjects;

[BsonSerializer(typeof(MongoEnumValueObjectSerializer<EnumValueObject<Enum>>))]
public class Country : EnumValueObject<CountryType>
{
    public Country(CountryType value) : base(value)
    {
    }
    
    public Country(string value) : base(ModifyValue(value))
    {
        
    }

    private static CountryType ModifyValue(string value)
    {
        Enum.TryParse(value, out CountryType country);
        return country;
    }

    protected Country()
    {
    }
}