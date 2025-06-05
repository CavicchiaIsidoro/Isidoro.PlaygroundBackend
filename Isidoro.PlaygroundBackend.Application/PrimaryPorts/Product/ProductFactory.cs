using Isidoro.PlaygroundBackend.Application.UseCases;

namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product
{
    public static class ProductFactory
    {
        public static IProductUseCase CreateProductUseCases()
        {
            return new ProductUseCase();
        }
    }
}
