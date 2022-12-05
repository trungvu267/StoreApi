using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StoreApi.Models;

public class Products
{
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("productId")]
    public string ProductId { get; set; }
    [BsonElement("quantity")]
    public int Quantity { get; set; }
    public Products(string productId, int quantity)
    {
        ProductId = productId;
        Quantity = quantity;
    } 
}


public class Cart
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    // [BsonElement("test")]
    // public string? Test { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("userId")]
    public string? UserId {get;set;}
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("addressId")]
    public string? AddressId {get;set;}
    [BsonElement("products")]
    public Products[]? Products {get;set;}

}