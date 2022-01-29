using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoBooleanValueObjectSerializer<IsVatZw>))]
public class IsVatZw : BooleanValueObject
{
    public IsVatZw()
    {
    }

    public IsVatZw(bool value) : base(value)
    {
    }
}