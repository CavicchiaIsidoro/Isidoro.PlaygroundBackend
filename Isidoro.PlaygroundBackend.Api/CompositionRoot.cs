using Isidoro.PlaygroundBackend.Api.Controllers;
using Isidoro.PlaygroundBackend.Application.ExternalPorts.Product;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product;
using Isidoro.PlaygroundBackend.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using static Isidoro.PlaygroundBackend.Infrastructure.DatabaseFactory;

namespace Isidoro.PlaygroundBackend.Api
{
    public class CompositionRoot : IControllerActivator
    {
        private readonly DbContextOptions<PlaygroundContext> _options;
        private readonly PlaygroundContext _context;

        public CompositionRoot()
        { 
            _options = new DbContextOptionsBuilder<PlaygroundContext>()
                .EnableSensitiveDataLogging()
                .UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Playground;Integrated Security=True;")
                .Options;
            _context = new PlaygroundContext(_options);
        }

        public object Create(ControllerContext context) => context.ActionDescriptor.ControllerTypeInfo switch
        {
            var type when type == typeof(ProductController) =>
                new ProductController(CreateProductUseCase()),

                _ => throw new InvalidOperationException("Unknow controller type")
            };

        public void Release(ControllerContext context, object controller)
        {
        }

        private IProductUseCase CreateProductUseCase()
            => Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.ProductFactory
            .CreateProductUseCases(
                CreateProductRepository(_context));
    }
}
