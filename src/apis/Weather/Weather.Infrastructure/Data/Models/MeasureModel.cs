namespace Weather.Infrastructure.Data.Models;
using Weather.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class MeasureModel : Measure
{
    [BsonElement("_id")]
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Guid { get; set; }
}