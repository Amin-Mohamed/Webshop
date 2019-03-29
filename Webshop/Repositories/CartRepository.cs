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
                return cart;
            }
        }

        public void Add(CartItem cartItem)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO cart_items (ProductId, CartId, Quantity) VALUES(@product_id, @cart_id, @quantity)", cartItem);
            }
        }
    }
}