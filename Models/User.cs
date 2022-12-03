using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StoreApi.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("name")]
    public string UserName { get; set; } = null!;
    [BsonElement("password")]

    public string Password { get; set; } = null!;

}