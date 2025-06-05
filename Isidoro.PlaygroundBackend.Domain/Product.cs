using Isidoro.PlaygroundBackend.Domain.Abstract;

namespace Isidoro.PlaygroundBackend.Domain
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
