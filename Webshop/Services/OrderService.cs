using System.Collections.Generic;
using Webshop.Models;
using Webshop.Repositories;

namespace Webshop.Services
{
    public class OrderService
    {
        public OrderRepository orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public List<Order> Get()
        {
            return orderRepository.Get();
        }

        public Order Get(int id)
        {
            return orderRepository.Get(id);
        }


    }
}