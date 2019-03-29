using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Cart Get(int CartId)
        {
            if (CartId < 1)
            {
                return null;
            }

            return cartRepository.Get(CartId);
        }

        public bool Add(CartItem cartItem)
        {
            if (cartItem == null) return false;
            if (!cartItem.GetType().GetProperties().Any(p => p.GetValue(cartItem) != null)) return false;

            cartRepository.Add(cartItem);
            return true;
        }
    }
}