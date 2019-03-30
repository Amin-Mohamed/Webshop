using System;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Webshop.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private string connectionString;
        private CartService cartService;

        public CartController(IConfiguration configuration)
        {
            this.connectionString = configuration.GetConnectionString("ConnectionString");
            this.cartService = new CartService(new CartRepository(this.connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cart>), StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var cart = cartService.Get();
            return Ok(cart);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Cart), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var cart = this.cartService.Get(id);
            if (cart != null)
            {
                return Ok(cart);
            }
            return NotFound();
        }
    }
}