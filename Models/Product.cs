using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace StoreApi.Models;

public class Rating
{
    [BsonElement("rate")]
    public double Rate { get; set; }
    [BsonElement("count")]
    public int Count { get; set; }
    public Rating(double rate, int count)
    {
        Rate = rate;
        Count = count;
    }
}
public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("price")]
    public double Price { get; set; } 
    [BsonElement("title")]

    public string Title { get; set; } = null!;
    [BsonElement("description")]

    public string Description { get; set; } = null!;
    [BsonElement("category")]

    public string Category { get; set; } = null!;
    [BsonElement("image")]

    public string Image { get; set; } = null!;
    [BsonElement("rating")]


    public Rating? Rating {get;set;} 

}