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
    public class OrderController : Controller
    {
        private readonly OrderService orderService;

        public OrderController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            this.orderService = new OrderService(new OrderRepository(connectionString));
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Order>), StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            var order = this.orderService.Get();
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound();
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
    }
}