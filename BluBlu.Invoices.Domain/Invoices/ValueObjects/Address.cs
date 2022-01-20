using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.Invoices.ValueObjects
{
    public class Address
    {
        [BsonElement("Street")] public string Street { get; set; }
        [BsonElement("City")] public string City { get; set; }
        [BsonElement("Country")] public string Country { get; set; }
        [BsonElement("PostCode")] public string PostCode { get; set; }
        [BsonElement("BuildingNumber")] public string BuildingNumber { get; set; }
        [BsonElement("FlatNumber")] public string FlatNumber { get; set; }
    }
}