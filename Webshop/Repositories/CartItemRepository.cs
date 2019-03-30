using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Webshop.Models;

namespace Webshop.Repositories
{
    public class CartItemRepository
    {
        private readonly string connectionString;

        public CartItemRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<CartItem> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var cartItem = connection.Query<CartItem>("SELECT * FROM cart_items").ToList();

                return cartItem;
            }
        }

        public void Add(CartItem cartItem)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO cart_items" +
                	"(CartId, ProductId, Quantity, TotalPrice) " +
                	"VALUES" +
                	"(@product_id, @cart_id, @quantity, total_price)", cartItem);
            }   
        }
    }
}
