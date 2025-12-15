using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Application.DTOs
{
    public class ClientDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public static explicit operator ClientDto(Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Name = client.Name ?? string.Empty
            };
        }
    }
}
