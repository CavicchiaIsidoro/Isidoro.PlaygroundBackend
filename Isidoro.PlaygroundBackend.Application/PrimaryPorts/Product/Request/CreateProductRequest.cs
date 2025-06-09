namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Request
{
    public class CreateProductRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
    }
}
