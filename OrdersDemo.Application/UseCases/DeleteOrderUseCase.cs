using OrdersDemo.Application.DTOs;
using OrdersDemo.Domain.Entities;
using OrdersDemo.Domain.Interfaces;

namespace OrdersDemo.Application.UseCases
{
    public class DeleteOrderUseCase
    {
        private readonly IOrderRepository orderRepository;

        public DeleteOrderUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void Execute(OrderDto orderDto)
        {
            orderRepository.DeleteOrder((Order)orderDto);
        }
    }
}
