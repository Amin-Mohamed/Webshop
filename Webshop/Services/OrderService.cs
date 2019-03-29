using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class OrderService
    {
        public OrderRepository OrderRepository { get; set; }
        public CartRepository CartRepository;

        public OrderService(OrderRepository orderRepository, CartRepository cartRepository)
        {
            this.OrderRepository = orderRepository;
            this.CartRepository = cartRepository;
        }

        public List<Order> Get()
        {
            return OrderRepository.Get();
        }

        public Order Get(int id)
        {
            return OrderRepository.Get(id);
        }
    }
}