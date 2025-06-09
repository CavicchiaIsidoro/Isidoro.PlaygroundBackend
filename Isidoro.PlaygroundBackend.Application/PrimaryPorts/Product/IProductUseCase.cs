using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Request;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response;

namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product
{
    public interface IProductUseCase
    {
        Task<GetProductsResponse> GetProductsAsync();
        Task<GetProductResponse> GetProductAsync(Guid id);
        Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request);
    }
}
