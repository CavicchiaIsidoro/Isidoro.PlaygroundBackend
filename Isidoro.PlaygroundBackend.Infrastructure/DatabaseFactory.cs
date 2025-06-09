using Isidoro.PlaygroundBackend.Application.ExternalPorts.Product;
using Isidoro.PlaygroundBackend.Infrastructure.Repository;

namespace Isidoro.PlaygroundBackend.Infrastructure
{
    public class DatabaseFactory
    {
        public static IProductRepository CreateProductRepository(PlaygroundContext context)
        {
            return new ProductRepository(context);
        }
    }
}
