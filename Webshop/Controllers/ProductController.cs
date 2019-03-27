using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private string connectionString;

        private readonly ProductService productService;

        public ProductController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectionString");
            productService = new ProductService(new ProductRepository(connectionString));
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<Product>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var product = productService.Get();
            return Ok(product);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var productItem = productService.Get(id);

            if (productItem != null)
            {
                return Ok(productItem);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]Product product)
        {
            var result = productService.Add(product);
            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int id)
        {
            var result = productService.Delete(id);

            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
