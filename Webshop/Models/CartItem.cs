using System;

namespace Webshop.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
        public string TotalPrice { get; set; }
    }
}
