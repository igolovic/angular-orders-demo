using OrdersDemo.Domain.Entities;

namespace OrdersDemo.Domain.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
    }
}
