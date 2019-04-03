using System.Collections.Generic;
using System.Linq;
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
                string.IsNullOrEmpty(product?.Description))
            {
                return false;
            }

            this.productRepository.Add(product);

            return true;
        }

        public bool Delete(int id)
        {
            using (var transaction = new TransactionScope())
            {
                var productItem = this.productRepository.Get(id);

                if (productItem == null)
                {
                    return false;
                }

                this.productRepository.Delete(id);

                transaction.Complete();

                return true;
            }
   }    }
}
