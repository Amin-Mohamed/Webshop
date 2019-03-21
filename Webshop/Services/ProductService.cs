using System;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class ProductService
    {
        private readonly ProductRepository ProductRepository;

        public ProductService(ProductRepository ProductRepository)
        {
            this.ProductRepository = ProductRepository;
        }
    }
}
