using Isidoro.PlaygroundBackend.Api.Controllers;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace Isidoro.PlaygroundBackend.Api
{
    public class CompositionRoot : IControllerActivator
    {
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
            .CreateProductUseCases();
    }
}
