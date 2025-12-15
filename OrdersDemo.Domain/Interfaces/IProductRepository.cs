using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Domain.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
    }
}
