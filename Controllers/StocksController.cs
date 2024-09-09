using Microsoft.AspNetCore.Mvc;
using STOCKS.Models;
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

        [HttpGet]
        public ActionResult<IEnumerable<Stock>> GetStocks()
        {
            return Ok(_stocks);
        }
        
        [HttpPost]
        public ActionResult<Stock> PostStock([FromBody] Stock stock)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            stock.Id = _nextId++;
            _stocks.Add(stock);
            
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
    }
}