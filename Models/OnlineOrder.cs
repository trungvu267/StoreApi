using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StoreApi.Models;

public class OnlineOrder
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("userId")]
    public string? UserId {get;set;}
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("addressId")]
    public string? AddressId {get;set;}
    [BsonElement("products")]
    public Products[]? Products {get;set;}

}