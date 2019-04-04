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
                var orders = connection.Query<Order>("SELECT * FROM orders").ToList();

                return orders;
            }
        }

        public Order Get(int id)
        {
            Order order = new Order();
            order.Id = id;

            using (var connection = new MySqlConnection(this.connectionString))
            {
                order = connection.Query<Order>("SELECT * FROM orders WHERE id=@id", new { id }).SingleOrDefault();

                order.Products = connection.Query<Product>("SELECT p.id, p.title, p.description, p.price FROM products AS p " +
                    "LEFT JOIN orderItems AS oi ON p.id = oi.product_id " +
                    "LEFT JOIN orders AS o ON oi.order_id = o.id " +
                    "WHERE o.id = @id",
                    new { id }).ToList();
            }
            return order;
        }

        public void Add(Order order)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO orders " +
                    "(customer_name, email, address) " +
                    "VALUES " +
                    "(@CustomerName, @Email, @Address)",
                    order);
                order.Id = connection.Query<int>("SELECT LAST_INSERT_ID();").FirstOrDefault();

                foreach (var product in order.Products)
                {
                    connection.Execute("INSERT INTO orderItems (product_id, order_id) VALUES (@ProductId, @OrderId)",
                        new { ProductId = product.Id, OrderId = order.Id });
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(this.connectionString))
            {
                connection.Execute("DELETE FROM orderItems WHERE orderId=@id;" +
                    " DELETE FROM orders WHERE id=@id", new { id });
            }
        }
    }
}