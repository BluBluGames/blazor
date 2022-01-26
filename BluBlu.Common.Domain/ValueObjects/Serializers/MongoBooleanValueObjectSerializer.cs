using System;
using MongoDB.Bson.Serialization;

namespace BluBlu.Common.Domain.ValueObjects.Serializers;

public class MongoDecimalValueObjectSerializer<TValueObject> : IBsonSerializer<TValueObject>
    where TValueObject : DecimalValueObject
{
    public Type ValueType => typeof(TValueObject);

    public TValueObject Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadDecimal128();
        
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), value)!;
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TValueObject? value)
    {
        if (value != null) context.Writer.WriteDecimal128(value.Value);
    }

    public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
    {
        if (value is TValueObject name)
            context.Writer.WriteDecimal128(name.Value);
        else
            throw new NotSupportedException("This type is not supported");
    }

    object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
    {
        var value = context.Reader.ReadDecimal128();
        return (TValueObject) Activator.CreateInstance(typeof(TValueObject), value)!;
    }
}