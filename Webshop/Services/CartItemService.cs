using System;
using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class CartItemService
    {
        private readonly CartItemRepository cartItemRepository;

        public CartItemService(CartItemRepository cartItemRepository)
        {
            this.cartItemRepository = cartItemRepository;
        }

        public List<CartItem> Get()
        {
            return this.cartItemRepository.Get();
        }

        public bool Add(CartItem cartItem)
        {
            if (cartItem == null)
            {
                return false;
            }

            this.cartItemRepository.Add(cartItem);

            return true;
        }

    }
}
