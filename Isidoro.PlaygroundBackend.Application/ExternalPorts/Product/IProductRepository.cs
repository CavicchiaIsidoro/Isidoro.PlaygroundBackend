namespace Isidoro.PlaygroundBackend.Application.ExternalPorts.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<Domain.Product>> GetAllAsync();
        Task<Domain.Product> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Domain.Product product);
    }
}
