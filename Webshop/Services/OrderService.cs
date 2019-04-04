using System.Collections.Generic;
using System.Transactions;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class OrderService
    {
        private readonly OrderRepository orderRepository;
        private readonly CartRepository cartRepository;

        public OrderService(OrderRepository orderRepository, CartRepository cartRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
        }

        public Order Get(int id)
        {
            return orderRepository.Get(id);
        }

        public Order Add(Order order)
        {
            if (order.CartId <= 0)
            {
                return null;
            }

            Cart orderCart = this.cartRepository.Get(order.CartId);

            order.Products = orderCart.Products;

            this.orderRepository.Add(order);

            this.cartRepository.Delete(order.CartId);

            return this.orderRepository.Get(order.Id);
        }

        public bool Delete(int id)
        {
            using (var transaction = new TransactionScope())
            {
                var orderItem = this.orderRepository.Get(id);

                if (orderItem == null)
                {
                    return false;
                }

                this.orderRepository.Delete(id);

                transaction.Complete();

                return true;
            }

        }
    }
}