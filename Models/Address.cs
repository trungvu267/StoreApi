using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StoreApi.Models;

public class Address
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("userId")]
    public string? UserId {get;set;}
    [BsonElement("street")]
    public string? Street {get;set;}
    [BsonElement("cellphone")]
    public string? Cellphone {get;set;}
    // [BsonElement("selected")]
    // [BsonDefaultValue(false)]
// public bool? Selected {get;set;}
}