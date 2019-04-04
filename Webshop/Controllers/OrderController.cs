using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Webshop.Controllers
{

    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly string connectionString;
        private readonly OrderService orderService;

        public OrderController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderService = new OrderService
                (
                    new OrderRepository(connectionString),
                    new CartRepository(connectionString)
                );
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Order), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Order), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var order = this.orderService.Get(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Order order)
        {
            var result = this.orderService.Add(order);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = this.orderService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}