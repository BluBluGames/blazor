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
    [BsonElement("FlatNumber")] public FlatNumber? FlatNumber { get; set; }

    public Address()
    {
    }
    
    public Address(
        Street street,
        PostCity postCity,
        Country country,
        PostCode postCode,
        BuildingNumber buildingNumber,
        FlatNumber? flatNumber)
    {
        Street = street;
        PostCity = postCity;
        Country = country;
        PostCode = postCode;
        BuildingNumber = buildingNumber;
        FlatNumber = flatNumber;
    }
}