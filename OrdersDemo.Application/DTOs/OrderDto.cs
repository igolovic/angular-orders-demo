using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Application.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public List<OrderItemDto> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        public static explicit operator Order(OrderDto dto)
        {
            return new Order
            {
                Id = dto.Id,
                ClientId = dto.ClientId,
                CreatedAt = dto.CreatedAt,
                ModifiedAt = dto.ModifiedAt,
                Items = dto.Items?.Select(i => (OrderItem)i).ToList()
            };
        }

        public static explicit operator OrderDto(Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                ClientId = order.ClientId,
                CreatedAt = order.CreatedAt,
                ModifiedAt = order.ModifiedAt,
                Items = order.Items?.Select(i => (OrderItemDto)i).ToList()
            };
        }
    }

}
