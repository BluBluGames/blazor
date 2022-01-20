using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.Invoices.ValueObjects
{
    public class Product
    {
        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("PricePerUnit")] public float PricePerUnit { get; set; }
        [BsonElement("NumberOfUnits")] public float NumberOfUnits { get; set; }
        [BsonElement("UnitName")] public string UnitName { get; set; }
        [BsonElement("Vat")] public float Vat { get; set; }
        [BsonElement("IsVatZw")] public bool isVatZw { get; set; }
        [BsonElement("PriceGross")] public float PriceGross { get; set; }
        [BsonElement("LegalBasisForTaxExemption")] public string LegalBasisForTaxExemption { get; set; }
    }
}