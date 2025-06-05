using Isidoro.PlaygroundBackend.Databuilder.Builders.Product;

namespace Isidoro.PlaygroundBackend.Databuilder
{
    public class BuilderProvider
    {
        public ProductBuilder AProduct() => new ProductBuilder();
    }
}
