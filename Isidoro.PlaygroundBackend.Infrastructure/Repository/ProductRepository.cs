using Isidoro.PlaygroundBackend.Application.ExternalPorts.Product;
using Isidoro.PlaygroundBackend.Domain;
using Isidoro.PlaygroundBackend.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Isidoro.PlaygroundBackend.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly PlaygroundContext _context;

        public ProductRepository(PlaygroundContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Product product)
        {
            var data = product.ToData();

            await _context.Products.AddAsync(data);
            await _context.SaveChangesAsync();

            return data.Id;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.ToDomain();
        }

        public async Task<Product> GetByIdAsync(Guid id)
        {
            var data = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return data.ToDomain();
        }
    }
}
