using System;

namespace Webshop.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
