using Webshop.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;
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

        public Cart Get(int id)
        {
            Cart cart = new Cart();
            cart.Id = id;
            using (var connection = new MySqlConnection(this.connectionString))
            {
                cart.Products = connection.Query<Product>("SELECT " +
                    "p.id, p.title, p.description, p.price FROM products AS p " +
                    "LEFT JOIN cartItems AS ci " +
                    "ON p.id = ci.product_id LEFT JOIN carts AS c" +
                    " ON ci.cart_id = c.id WHERE c.id = @id",new { id }).ToList();
                return cart;
            }
        }

        public int Create()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO carts() VALUES ()");
                return connection.Query<int>("SELECT LAST_INSERT_ID();").FirstOrDefault();
            }
        }

        public void Add(CartItem cartItem)
        {
            int? cartId = cartItem.CartId;
            int productId = cartItem.ProductId;

            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cartItems(product_id, cart_id) VALUES (@productId, @cartId)",
                    cartItem);
            }
        }
    }
}