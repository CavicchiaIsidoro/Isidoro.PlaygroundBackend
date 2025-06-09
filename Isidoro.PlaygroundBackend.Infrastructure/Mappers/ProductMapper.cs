using Isidoro.PlaygroundBackend.Infrastructure.Models;

namespace Isidoro.PlaygroundBackend.Infrastructure.Mappers
{
    public static class ProductMapper
    {
        public static Domain.Product ToDomain(this Product model)
        {
            return new Domain.Product
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Price = Convert.ToDouble(model.Price)
            };
        }

        public static IEnumerable<Domain.Product> ToDomain(this IEnumerable<Product> listModel)
            => listModel.Select(p => p.ToDomain());

        public static Product ToData(this Domain.Product model)
        {
            return new Product
            {
                Id = model.Id,
                Name = model.Name ?? string.Empty,
                Description = model.Description,
                Price = Convert.ToDecimal(model.Price)
            };
        }

        public static IEnumerable<Product> ToData(this IEnumerable<Domain.Product> listModel)
            => listModel.Select(p => p.ToData());
    }
}
