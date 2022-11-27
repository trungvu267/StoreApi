namespace StoreApi.Models
{
    public class Product
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public float? Price { get; set; }
        public string? Category {get;set;}
    }
}