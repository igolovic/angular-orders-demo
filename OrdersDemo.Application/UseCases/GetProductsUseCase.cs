using OrdersDemo.Application.DTOs;
using OrdersDemo.Domain.Interfaces;

namespace OrdersDemo.Application.UseCases
{
    public class GetProductsUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductsUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<ProductDto> Execute()
        {
            var products = from p in productRepository.GetProducts()
                           select (ProductDto)p;

            return products;
        }
    }
}
