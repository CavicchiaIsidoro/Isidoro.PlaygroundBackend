using Isidoro.PlaygroundBackend.Application.ExternalPorts.Product;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Request;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response;
using Isidoro.PlaygroundBackend.Application.UseCases.Mappers;

namespace Isidoro.PlaygroundBackend.Application.UseCases
{
    internal sealed class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                    throw new Exception(nameof(request.Name) + " should not be null or empty");

                if (request.Price == null)
                    throw new Exception(nameof(request.Price) + " should not be null");

                var id = await _productRepository.CreateAsync(request.ToDomain());

                return new CreateProductResponse(true, null, id);
            }
            catch (Exception e)
            {
                return new CreateProductResponse(false, e.Message, null);
            }

        }

        public async Task<GetProductResponse> GetProductAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product.ToProductResponse();
        }

        public async Task<GetProductsResponse> GetProductsAsync()
        {
            var response = new GetProductsResponse();
            var products = await _productRepository.GetAllAsync();

            response.Products = products.ToProductResponse();

            return response;
        }
    }
}
