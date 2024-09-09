using Microsoft.Extensions.Options;
using MongoDB.Driver;
using STOCKS.Models;


namespace STOCKS.Data
{

 public class Stockdb
 {
    private readonly IMongoCollection<Stock> _stocksCollection;

     public Stockdb(IOptions<mongoDbConfiguration> mongoDbConfiguration_)
     {
         var mongoClient = new MongoClient(mongoDbConfiguration_.Value.ConnectionString);

         var mongoDatabase = mongoClient.GetDatabase(mongoDbConfiguration_.Value.DatabaseName);

         _stocksCollection = mongoDatabase.GetCollection<Stock>(mongoDbConfiguration_.Value.StocksCollectionName);
     }

     public async Task AddStock(Stock newStock) => await _stocksCollection.InsertOneAsync(newStock);

     public async Task<List<Stock>> GetAllStocks() => await _stocksCollection.Find(_ => true).ToListAsync();

 }

}