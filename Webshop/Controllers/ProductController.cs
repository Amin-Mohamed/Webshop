using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Webshop.Models;
using Webshop.Repositories;
using Webshop.Services;

namespace Webshop.Controllers
{
    public class ProductController : Controller
    {
        private string connectionString;
        private readonly ProductService productService;

        public ProductController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("ConnectionString");
            productService = new ProductService(new ProductRepository(connectionString));
        }
    }
}
