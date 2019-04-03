//using System;
//using System.Collections.Generic;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using Webshop.Models;
//using Webshop.Repositories;
//using Webshop.Services;

//namespace Webshop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CartItemsController : ControllerBase
//    {
//        private readonly string connectionString;
//        private readonly CartItemService cartItemsService;

//        public CartItemsController(IConfiguration configuration)
//        {
//            this.connectionString = configuration.GetConnectionString("ConnectionString");
//            this.cartItemsService = new CartItemService(new CartItemRepository(connectionString));

//        }

//        //[HttpGet]
//        //[ProducesResponseType(typeof(List<CartItem>), StatusCodes.Status200OK)]
//        //public IActionResult Get()
//        //{
//        //    var cartitem = cartItemsService.Get();
//        //    return Ok(cartitem);
//        //}


//        // GET api/cartitems/2
//        [HttpGet("{id}")]
//        [ProducesResponseType(typeof(CartItem), StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]

//        public IActionResult Get(int id)
//        {
//            var cartItems = cartItemsService.Get(id);

//            if (cartItems == null)
//            {
//                return NotFound();
//            }

//            //if (cartItems.Count == 0)
//            //{
//            //    return NotFound();
//            //}

//            return Ok(cartItems);
//        }


//        // POST api/products/
//        [HttpPost]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status400BadRequest)]

//        public IActionResult Post([FromBody]CartItem cartItem)
//        {
//            var result = this.cartItemsService.Add(cartItem);

//            if (!result)
//            {
//                return BadRequest();
//            }

//            return Ok();
//        }

//        // DELETE api/cartitems/5
//        [HttpDelete("{id}")]
//        [ProducesResponseType(StatusCodes.Status200OK)]
//        [ProducesResponseType(StatusCodes.Status404NotFound)]
//        public IActionResult Delete(int id)
//        {

//            var result = this.cartItemsService.Delete(id);

//            if (!result)
//            {
//                return NotFound();
//            }

//            return Ok();
//        }
//    }
//}
