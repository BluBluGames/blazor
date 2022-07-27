using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using BluBlu.Stocks.Common.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Stocks.Domain.StockEntity.ValueObjects;

[BsonSerializer(typeof(MongoEnumValueObjectSerializer<EnumValueObject<Enum>>))]
public class Sector : EnumValueObject<SectorType>
{
    public Sector(SectorType value) : base(value)
    {
    }

    protected Sector()
    {
    }
}