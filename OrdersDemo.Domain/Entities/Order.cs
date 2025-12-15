namespace OrdersDemo.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new();
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
    }
}