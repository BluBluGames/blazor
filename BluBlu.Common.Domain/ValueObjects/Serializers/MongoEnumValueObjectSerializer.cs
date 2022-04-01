using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;

namespace BluBlu.Common.Domain.ValueObjects.Serializers;

public class MongoEnumValueObjectSerializer<TValueObject> : IBsonSerializer<TValueObject>
    where TValueObject : EnumValueObject<Enum>
{
    public Type ValueType => typeof(TValueObject);

    public TValueObject Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadString();
        
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), value)!;
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TValueObject? value)
    {
        context.Writer.WriteString(value?.Value?.ToString());
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object? value)
    {
        switch (value)
        {
            case TValueObject name:
                context.Writer.WriteString(name.Value?.ToString());
                break;
            case null:
                context.Writer.WriteNull();
                break;
            default:
                throw new NotSupportedException("This type is not supported");
        }
    }

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        if (context.Reader.CurrentBsonType == BsonType.Null)
        {
            context.Reader.ReadNull();
            return (TValueObject) Activator.CreateInstance(typeof(TValueObject), null)!;
        }

        var value = context.Reader.ReadString();
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), value)!;
    }
}