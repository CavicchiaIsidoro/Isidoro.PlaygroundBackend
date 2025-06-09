using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Request;
using Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response;

namespace Isidoro.PlaygroundBackend.Application.UseCases.Mappers
{
    public static class ProductMapper
    {
        public static GetProductResponse ToProductResponse(this Domain.Product model)
        {
            return new GetProductResponse
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
        }

        public static IEnumerable<GetProductResponse> ToProductResponse(this IEnumerable<Domain.Product> listModel)
            => listModel.Select(p => p.ToProductResponse());

        public static Domain.Product ToDomain(this CreateProductRequest model)
        {
            return new Domain.Product
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };
        }
    }
}
