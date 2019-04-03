using System.Collections.Generic;
using System.Transactions;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class ProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public List<Product> Get()
        {
            return productRepository.Get();
        }

        public Product Get(int id)
        {
            return productRepository.Get(id);
        }

        public bool Add(Product product)
        {
            if (string.IsNullOrEmpty(product?.Title) ||
                string.IsNullOrEmpty(product?.Description) ||
                product?.Price == null
                )
            {
                return false;
            }

            this.productRepository.Add(product);

            return true;
        }
   }
}
