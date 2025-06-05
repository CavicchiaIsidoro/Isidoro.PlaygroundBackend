using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response;
using Microsoft.AspNetCore.Mvc;

namespace Isidoro.PlaygroundBackend.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductUseCase _productUseCase;
        public ProductController(
            IProductUseCase productUseCase)
        {
            _productUseCase = productUseCase;
        }

        [HttpGet]
        public async Task<GetProductsResponse> Get()
        {
            var response = await _productUseCase.GetProducts();
            return response;
        }
    }
}
