using BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.InvoicesAggregate.ProductsEntity;

public class Product
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("Name")] public Name Name { get; set; } = null!;
    [BsonElement("PriceNet")] public PriceNet PriceNet { get; set; } = null!;
    [BsonElement("UnitName")] public UnitName UnitName { get; set; } = null!;
    [BsonElement("Vat")] public Vat Vat { get; set; } = null!;
    [BsonElement("IsVatZw")] public IsVatZw IsVatZw { get; set; } = null!;
    [BsonElement("PriceGross")] public PriceGross PriceGross { get; set; } = null!;
    [BsonElement("LegalBasisForTaxExemption")] public LegalBasisForTaxExemption? LegalBasisForTaxExemption { get; set; } = null!;

    public Product()
    {
    }
    
    public Product(
        Name name,
        PriceNet priceNet,
        UnitName unitName,
        Vat vat,
        IsVatZw isVatZw,
        PriceGross priceGross,
        LegalBasisForTaxExemption? legalBasisForTaxExemption)
    {
        Name = name;
        PriceNet = priceNet;
        UnitName = unitName;
        Vat = vat;
        IsVatZw = isVatZw;
        PriceGross = priceGross;
        LegalBasisForTaxExemption = legalBasisForTaxExemption;
    }
}