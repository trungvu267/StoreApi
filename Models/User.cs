using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StoreApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string userName { get; set; } = null!;
    public string password { get; set; } = null!;

}