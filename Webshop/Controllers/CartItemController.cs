using System;
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
    public class CartItemController : Controller
    {
        private readonly CartItemService cartItemService;

        public CartItemController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartItemService = new CartItemService(new CartItemRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
        public IActionResult Get()
        { 
             var cartItem = cartItemService.Get();
             return Ok(cartItem);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody]CartItem cartItem)
        {
            var result = this.cartItemService.Add(cartItem);

            if (!result)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
