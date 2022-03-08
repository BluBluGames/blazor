using BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity;

public class Contractor
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("Name")] public Name Name { get; set; } = null!;
    [BsonElement("Address")] public Address Address { get; set; } = null!;
    [BsonElement("Nip")] public Nip? Nip { get; set; } = null!;

    public Contractor()
    {
    }

    public Contractor(Name name, Address address, Nip? nip)
    {
        Name = name;
        Address = address;
        Nip = nip;
    }
}