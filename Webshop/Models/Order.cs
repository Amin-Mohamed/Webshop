using System.Collections.Generic;

namespace Webshop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CartId { get; set; }
        public List<Product> Products { get; set; }
    }
}
