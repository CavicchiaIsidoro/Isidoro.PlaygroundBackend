using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response;

namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product
{
    public interface IProductUseCase
    {
        Task<GetProductsResponse> GetProducts();
    }
}
