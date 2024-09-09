using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace STOCKS.Models
{
    public class Stock
    {
        [BsonId]
        public int Id { get; set; }

        [BsonElement("symbol")]
        public string Symbol { get; set; } 

        [BsonElement("name")]
        public string Name { get; set; } 

        [BsonElement("quantity")]        
        public int Quantity { get; set; } 
        
        [BsonElement("price")]
        public decimal Price { get; set; } 
    }
}
