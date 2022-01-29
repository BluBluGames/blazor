using BluBlu.Common.Domain.ValueObjects;
using BluBlu.Common.Domain.ValueObjects.Serializers;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;

[BsonSerializer(typeof(MongoStringValueObjectSerializer<LegalBasisForTaxExemption>))]
public class LegalBasisForTaxExemption : StringValueObject
{
    public LegalBasisForTaxExemption()
    {
    }

    public LegalBasisForTaxExemption(string value) : base(value, 250)
    {
    }
}