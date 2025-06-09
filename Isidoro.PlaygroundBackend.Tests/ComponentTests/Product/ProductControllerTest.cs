using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Request;
using Isidoro.PlaygroundBackend.Databuilder;
using Isidoro.PlaygroundBackend.Databuilder.Builders.Abstract;
using Isidoro.PlaygroundBackend.Infrastructure;
using Isidoro.PlaygroundBackend.Tests.ComponentTests.Product.Builder;
using Shouldly;

namespace Isidoro.PlaygroundBackend.Tests.ComponentTests.Product
{
    public class ProductControllerTest : IClassFixture<DatabaseFixture>
    {
        private readonly BuilderProvider _bob;
        private readonly PlaygroundContext _context;

        public ProductControllerTest(DatabaseFixture databaseFixture)
        {
            _context = databaseFixture.DatabaseBulder.Build();
            _bob = new BuilderProvider(_context);
        }

        [Fact]
        public async Task Get_All_Product()
        {
            var productController = ProductControllerBuilder.AProductController(_context).Build();
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

        [Fact]
        public async Task Get_A_Product_With_Id()
        {
            var controller = ProductControllerBuilder.AProductController(_context).Build();
            var product1 = await _bob.AProduct().WithName("ProductId001").InsertDataAsync();
            var product2 = await _bob.AProduct().InsertDataAsync();
            var product3 = await _bob.AProduct().InsertDataAsync();

            var response = await controller.Get(product1.Id, null);

            response.ShouldNotBeNull();
            response.Id.ShouldBe(product1.Id);
            response.Name.ShouldBe(product1.Name);
            response.Description.ShouldBe(product1.Description);
            response.Price.ShouldBe(product1.Price);
        }

        [Fact]
        public async Task Create_A_Product_Without_Name_Doesnt_Work()
        {
            var controller = ProductControllerBuilder.AProductController(_context).Build();
            var request = new CreateProductRequest()
            {
                Name = null,
                Description = null,
                Price = 0.0
            };

            var response = await controller.Create(request);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeFalse();
            response.Message?.ShouldContain($"{nameof(request.Name)} should not be null or empty");
        }

        [Fact]
        public async Task Create_A_Product_Without_Price_Doesnt_Work()
        {
            var controller = ProductControllerBuilder.AProductController(_context).Build();
            var request = new CreateProductRequest()
            {
                Name = "Product000",
                Description = "Product without Price",
                Price = null
            };

            var response = await controller.Create(request);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeFalse();
            response.Message?.ShouldContain($"{nameof(request.Price)} should not be null");
        }

        [Fact]
        public async Task Create_A_Product()
        {
            var controller = ProductControllerBuilder.AProductController(_context).Build();
            var request = new CreateProductRequest()
            {
                Name = "Procut001",
                Description = "Description for Product001",
                Price = 2.1
            };

            var response = await controller.Create(request);

            response.ShouldNotBeNull();
            response.IsSuccess.ShouldBeTrue();
            response.Id.ShouldNotBeNull();
        }
    }
}
