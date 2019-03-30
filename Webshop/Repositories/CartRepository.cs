using System.Linq;
using Webshop.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Webshop.Repositories
{
    public class CartRepository
    {
        private readonly string connectionString;

        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cart> Get()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                return connection.Query<Cart>("SELECT * FROM cart").ToList();
            }
        }

        public Cart Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cart = connection.QuerySingleOrDefault<Cart>("SELECT * FROM cart WHERE id = @id", new { id });
                //CartItem
                cart.Products = connection.Query<Product>("SELECT * FROM cart_items c" +
                	"INNER JOIN products p ON c.product_id = p.id " +
                	"WHERE c.cart_id = @id", new { id }).ToList();

                return cart;
            }
        }
    }
}