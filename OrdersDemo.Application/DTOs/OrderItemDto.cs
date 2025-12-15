using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Application.DTOs
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public static explicit operator OrderItem(OrderItemDto dto)
        {
            return new OrderItem
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
        }

        public static explicit operator OrderItemDto(OrderItem item)
        {
            return new OrderItemDto
            {
                Id = item.Id,
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                Quantity = item.Quantity
            };
        }
    }
}
