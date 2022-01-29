using System;
using MongoDB.Bson.Serialization;

namespace BluBlu.Common.Domain.ValueObjects.Serializers;

public class MongoDateTimeValueObjectSerializer<TValueObject> : IBsonSerializer<TValueObject>
    where TValueObject : DateTimeValueObject
{
    public Type ValueType => typeof(TValueObject);

    public TValueObject Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadDateTime();
        
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), new DateTime(value))!;
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TValueObject? value)
    {
        if (value != null) context.Writer.WriteDateTime(value.Value.Ticks);
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object? value)
    {
        switch (value)
        {
            case TValueObject name:
                context.Writer.WriteDateTime(name.Value.Ticks);
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
        var value = context.Reader.ReadDateTime();
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), new DateTime(value))!;
    }
}