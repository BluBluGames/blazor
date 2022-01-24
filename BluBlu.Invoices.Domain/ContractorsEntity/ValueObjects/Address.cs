using BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects.AddressVO;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Invoices.Domain.ContractorsEntity.ValueObjects;

public class Address
{
    [BsonElement("Street")] public Street Street { get; set; }
    [BsonElement("PostCity")] public PostCity PostCity { get; set; }
    [BsonElement("Country")] public Country Country { get; set; }
    [BsonElement("PostCode")] public PostCode PostCode { get; set; }
    [BsonElement("BuildingNumber")] public BuildingNumber BuildingNumber { get; set; }
    [BsonElement("FlatNumber")] public FlatNumber FlatNumber { get; set; }

    public Address(
        string street,
        string postCity,
        string country,
        string postCode,
        string buildingNumber,
        string flatNumber)
    {
        Street = new(street);
        PostCity = new(postCity);
        Country = new(country);
        PostCode = new(postCode);
        BuildingNumber = new(buildingNumber);
        FlatNumber = new(flatNumber);
    }
}