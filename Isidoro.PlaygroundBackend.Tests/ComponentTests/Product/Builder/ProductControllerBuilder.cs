using Isidoro.PlaygroundBackend.Api.Controllers;
using Isidoro.PlaygroundBackend.Infrastructure;
using Isidoro.PlaygroundBackend.Tests.ComponentTests.Abstract;
using static Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.ProductFactory;
using static Isidoro.PlaygroundBackend.Infrastructure.DatabaseFactory;

namespace Isidoro.PlaygroundBackend.Tests.ComponentTests.Product.Builder
{
    public class ProductControllerBuilder : BaseControllerBuilder
    {
        public static ProductControllerBuilder AProductController(PlaygroundContext context)
            => new ProductControllerBuilder(context);

        public ProductControllerBuilder(PlaygroundContext context)
            : base (context)
        {
        }

        public ProductController Build()
        {
            var productController = new ProductController(
                CreateProductUseCases(
                    CreateProductRepository(_context)));

            return productController;
        }
    }
}
