using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.Invoices.ValueObjects
{
    public class Contractor
    {
        [BsonElement("Name")] public string Name { get; set; }
        [BsonElement("Address")] public Address Address { get; set; }
        [BsonElement("Nip")] public string Nip { get; set; }
    }
}