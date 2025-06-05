namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response
{
    public class GetProductsResponse
    {
        public IEnumerable<GetProductResponse>? Products { get; set; }
    }
}
