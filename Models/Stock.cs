namespace Stocks.Models
{
    public class Stocks.Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } 
        
        public string Name { get; set; } 
        
        public int Quantity { get; set; } 
        
        public decimal Price { get; set; } 
    }
}
