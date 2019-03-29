using System;
using System.Collections.Generic;

namespace Webshop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public Cart Cart { get; set; }
    }
}
