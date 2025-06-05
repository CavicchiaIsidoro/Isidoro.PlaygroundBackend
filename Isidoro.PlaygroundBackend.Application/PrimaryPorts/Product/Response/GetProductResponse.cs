namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response
{
    public class GetProductResponse
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
