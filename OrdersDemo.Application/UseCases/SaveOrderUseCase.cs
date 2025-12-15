using OrdersDemo.Application.DTOs;
using OrdersDemo.Domain.Entities;
using OrdersDemo.Domain.Interfaces;

namespace OrdersDemo.Application.UseCases
{
    public class SaveOrderUseCase
    {
        private readonly IOrderRepository orderRepository;

        public SaveOrderUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public OrderDto Execute(OrderDto order)
        {
            return (OrderDto)orderRepository.SaveOrder((Order)order);
        }
    }
}
