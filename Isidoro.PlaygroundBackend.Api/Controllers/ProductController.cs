using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Request;
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
            var response = await _productUseCase.GetProductsAsync();
            return response;
        }

        [HttpGet("{id}")]
        public async Task<GetProductResponse> Get(Guid id, [FromQuery] string? name)
        {
            var response = await _productUseCase.GetProductAsync(id);
            return response;
        }

        [HttpPost]
        public async Task<CreateProductResponse> Create([FromBody] CreateProductRequest request)
        {
            var response = await _productUseCase.CreateProductAsync(request);
            return response;
        }
    }
}
