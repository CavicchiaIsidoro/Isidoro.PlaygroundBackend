using Isidoro.PlaygroundBackend.Databuilder;
using Isidoro.PlaygroundBackend.Tests.ComponentTests.Product.Builder;
using Shouldly;

namespace Isidoro.PlaygroundBackend.Tests.ComponentTests.Product
{
    public class ProductControllerTest
    {
        private readonly BuilderProvider _bob;

        public ProductControllerTest()
        {
            _bob = new BuilderProvider();
        }

        [Fact]
        public async Task Get_All_Product()
        {
            var productController = ProductControllerBuilder.AProductController().Build();
            var product1 = await _bob.AProduct().InsertDataAsync();
            var product2 = await _bob.AProduct().InsertDataAsync();
            var product3 = await _bob.AProduct().WithName("Test Product").InsertDataAsync();

            var response = await productController.Get();

            response.Products.ShouldNotBeNull();
            response.Products.ShouldNotBeEmpty();

            response.Products.ShouldContain(p => p.Id == product1.Id);
            response.Products.ShouldContain(p => p.Name == product1.Name);
            response.Products.ShouldContain(p => p.Description == product1.Description);
            response.Products.ShouldContain(p => p.Price == product1.Price);

            response.Products.ShouldContain(p => p.Id == product2.Id);
            response.Products.ShouldContain(p => p.Name == product2.Name);
            response.Products.ShouldContain(p => p.Description == product2.Description);
            response.Products.ShouldContain(p => p.Price == product2.Price);

            response.Products.ShouldContain(p => p.Id == product3.Id);
            response.Products.ShouldContain(p => p.Name == product3.Name);
            response.Products.ShouldContain(p => p.Description == product3.Description);
            response.Products.ShouldContain(p => p.Price == product3.Price);
        }
    }
}
