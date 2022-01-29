using System;
using MongoDB.Bson.Serialization;

namespace BluBlu.Common.Domain.ValueObjects.Serializers;

public class MongoBooleanValueObjectSerializer<TValueObject> : IBsonSerializer<TValueObject>
    where TValueObject : BooleanValueObject
{
    public Type ValueType => typeof(TValueObject);

    public TValueObject Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadBoolean();
        
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), value)!;
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TValueObject? value)
    {
        if (value != null) context.Writer.WriteBoolean(value.Value);
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object? value)
    {
        switch (value)
        {
            case TValueObject name:
                context.Writer.WriteBoolean(name.Value);
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
        var value = context.Reader.ReadBoolean();
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), value)!;
    }
}