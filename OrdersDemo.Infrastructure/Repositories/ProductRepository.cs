using Microsoft.EntityFrameworkCore;
using OrdersDemo.Domain.Entities;
using OrdersDemo.Domain.Interfaces;
using OrdersDemo.Infrastructure.Persistence;

namespace OrdersDemo.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly OrdersDbContext context;

        public ProductRepository(OrdersDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetProducts()
        {
            return context.Products
                .AsNoTracking()
                .AsEnumerable();
        }
    }
}
