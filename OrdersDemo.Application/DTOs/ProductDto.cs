using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Application.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }

        public static explicit operator ProductDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name
            };
        }
    }
}
