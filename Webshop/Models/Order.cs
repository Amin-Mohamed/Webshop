using System.Collections.Generic;

namespace Webshop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
        public string CustomerName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }   
    }
}
