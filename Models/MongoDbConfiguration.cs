namespace STOCKS.Models
{
    public class mongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string StocksCollectionName { get; set; }
    }
}