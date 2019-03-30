using System.Collections.Generic;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Webshop.Models;

namespace Webshop.Repositories
{
    public class OrderRepository
    {
        private readonly string connectionString;

        public OrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Order> Get()
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var orders = connection.Query<Order>("SELECT * FROM Orders").ToList();

                return orders;
            }

        }

        public Order Get(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                var order = connection.QuerySingleOrDefault<Order>("SELECT * FROM orders WHERE Id = @id", new { id });

                return order;
            }
        }

        public int Create(Cart cart)
        {
            using (var Connection = new MySqlConnection(this.connectionString))
            {
                var cartId = cart.CartId;

                var orderId = Connection.Execute("INSERT INTO Orders " +
                    "(CartId, CustomerName, Adress, Email) " +
                    "VALUES " +
                    "(@cart_id, @customer_name, @adress, @eamil)", new { cartId, });

                return orderId;
            }
        }
    }
}