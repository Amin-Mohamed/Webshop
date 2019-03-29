using System;
using System.Collections.Generic;

namespace Webshop.Models
{
    public class Cart
    {
        public int CartId { get; set; }
        public List<Product> Products { get; set; }
        public int TotalPrice { get; set; }
    }
}
