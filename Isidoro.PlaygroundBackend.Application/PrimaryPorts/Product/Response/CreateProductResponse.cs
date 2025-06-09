namespace Isidoro.PlaygroundBackend.Application.PrimaryPorts.Product.Response
{
    public record CreateProductResponse(bool IsSuccess, string? Message, Guid? Id);
}
