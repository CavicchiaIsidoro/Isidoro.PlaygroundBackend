using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response;

namespace Isidoro.PlaygroundBackend.Application.UseCases
{
    internal sealed class ProductUseCase : IProductUseCase
    {
        public async Task<GetProductsResponse> GetProducts()
        {
            var response = new GetProductsResponse();
            response.Products = new List<GetProductResponse>();

            return response;
        }
    }
}
