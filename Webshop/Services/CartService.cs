using System.Transactions;
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

        public Cart Get(int id)
        {
            return this.cartRepository.Get(id);
        }

        public bool Add(CartItem cartItem)
        {
            if (cartItem.CartId != null && cartItem.CartId <= 0)
            {
                return false;
            }

            if (cartItem.CartId == null)
            {
                cartItem.CartId = this.cartRepository.Create();
            }

            this.cartRepository.Add(cartItem);
            return true;
        }
    }
}