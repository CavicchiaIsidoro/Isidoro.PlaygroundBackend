using Isidoro.PlaygroundBackend.Application.ExternalPorts.Product;
using Isidoro.PlaygroundBackend.Application.UseCases;

namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product
{
    public static class ProductFactory
    {
        public static IProductUseCase CreateProductUseCases(IProductRepository productRepository)
        {
            return new ProductUseCase(productRepository);
        }
    }
}
