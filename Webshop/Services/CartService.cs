using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class CartService
    {
        private readonly CartRepository cartRepository;

        public CartService(CartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        public List<Cart> Get()
        {
            return cartRepository.Get();
        }

        public Cart Get(int id)
        {
            return cartRepository.Get(id);
        }
    }
}