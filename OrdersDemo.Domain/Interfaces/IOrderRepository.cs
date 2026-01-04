using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Domain.Interfaces
{
    public interface IOrderRepository
    {
        void DeleteOrder(Order order);
        Order SaveOrder(Order order);
    }
}
