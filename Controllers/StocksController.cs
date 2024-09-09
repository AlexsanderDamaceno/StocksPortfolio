using Microsoft.AspNetCore.Mvc;
using STOCKS.Models;
using STOCKS.Data;
using System.Collections.Generic;
using System.Linq;

namespace STOCKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private static List<Stock> _stocks = new List<Stock>();
        private static int _nextId = 1;

        private readonly Stockdb _stockDb;

        public StocksController(Stockdb stockDb)
        {
            _stockDb = stockDb;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            var stocks = await _stockDb.GetAllStocks();

            if (stocks == null)
            {
                return NotFound("Error Getting Stocks");
            }

            return Ok(stocks);
        }
        
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _stockDb.AddStock(stock);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult EditStock(int id, [FromBody] Stock stock)
        {
            var Stock = _stocks.FirstOrDefault(s => s.Id == id);
            
            if (Stock == null)
            {
                return NotFound(new { message = $"Stock with ID {id} not found." });
            }

            Stock.Symbol = stock.Symbol;
            Stock.Name = stock.Name;
            Stock.Quantity = stock.Quantity;
            Stock.Price = stock.Price;

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStock(int id)
        {
            var stock = _stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
            {
                return NotFound(new { message = $"Stock with ID {id} not found." });
            }

            _stocks.Remove(stock);
            return Ok();
        }
    }
}