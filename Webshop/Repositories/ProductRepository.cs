using System.Collections.Generic;
using Webshop.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Webshop.Repositories
{
    public class ProductRepository
    {
        private readonly string connectionString;

        public ProductRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Product> Get()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                return connection.Query<Product>("SELECT * FROM products").ToList();
            }
        }

        public Product Get(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                return connection.QuerySingleOrDefault<Product>("SELECT * FROM products WHERE Id = @id", new { id });
            }
        }

        public void Add(Product Product)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Execute("INSERT INTO products " +
                	"(name, description, price) " +
                	"VALUES" +
                	"(@name, @description, @price)", Product);
            }
        }

        public void Delete(int id)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Execute("DELETE FROM products WHERE id=@id", new { id });
            }
        }

    }
}
