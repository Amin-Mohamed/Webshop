using System.Collections.Generic;

namespace Webshop.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }
    }
}
