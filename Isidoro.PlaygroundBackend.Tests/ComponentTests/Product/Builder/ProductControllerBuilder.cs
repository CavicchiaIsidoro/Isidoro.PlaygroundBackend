using Isidoro.PlaygroundBackend.Api.Controllers;
using Isidoro.PlaygroundBackend.Tests.ComponentTests.Abstract;
using static Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.ProductFactory;

namespace Isidoro.PlaygroundBackend.Tests.ComponentTests.Product.Builder
{
    public class ProductControllerBuilder : BaseControllerBuilder
    {
        public static ProductControllerBuilder AProductController()
            => new ProductControllerBuilder();

        public ProductControllerBuilder()
            : base ()
        {
        }

        public ProductController Build()
        {
            var productController = new ProductController(
                CreateProductUseCases());

            return productController;
        }
    }
}
