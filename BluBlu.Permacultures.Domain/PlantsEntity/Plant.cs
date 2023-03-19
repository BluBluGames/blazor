using BluBlu.Permacultures.Domain.PlantsEntity.ValueObjects;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BluBlu.Permacultures.Domain.PlantsEntity;

public class Plant
{
    [BsonId] [BsonRepresentation(BsonType.ObjectId)] [BsonIgnoreIfDefault] public string Id { get; set; } = null!;
    [BsonElement("Name")] public Name Name { get; set; } = null!;
    [BsonElement("MonthOfPicking")] public MonthOfPicking MonthOfPicking { get; set; } = null!;
    [BsonElement("Sweetness")] public Sweetness Sweetness { get; set; } = null!;
    [BsonElement("Description")] public Description Description { get; set; } = null!;
    [BsonElement("ClimateType")] public ClimateType ClimateType { get; set; } = null!;
    [BsonElement("SoilPH")] public SoilType SoilType { get; set; } = null!;

    public Plant()
    {
    }

    public Plant(Name name)
    {
        Name = name;
    }
}