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
    }
}