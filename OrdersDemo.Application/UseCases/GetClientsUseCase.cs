using OrdersDemo.Application.DTOs;
using OrdersDemo.Domain.Interfaces;

namespace OrdersDemo.Application.UseCases
{
    public class GetClientsUseCase
    {
        private readonly IClientRepository clientRepository;

        public GetClientsUseCase(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public IEnumerable<ClientDto> Execute()
        {
            var clients = from c in clientRepository.GetClients()
                          select (ClientDto)c;

            return clients;
        }
    }
}
