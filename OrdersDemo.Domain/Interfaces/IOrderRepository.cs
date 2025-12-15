using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Order SaveOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
