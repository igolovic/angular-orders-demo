using Microsoft.EntityFrameworkCore;
using OrdersDemo.Domain.Entities;
using OrdersDemo.Domain.Interfaces;
using OrdersDemo.Infrastructure.Persistence;

namespace OrdersDemo.Infrastructure
{
    public class ClientRepository : IClientRepository
    {
        private readonly OrdersDbContext context;

        public ClientRepository(OrdersDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return context.Clients
                .AsNoTracking()
                .AsEnumerable();
        }
    }
}
