using Isidoro.PlaygroundBackend.Databuilder.Builders.Product;
using Isidoro.PlaygroundBackend.Infrastructure;

namespace Isidoro.PlaygroundBackend.Databuilder
{
    public class BuilderProvider
    {
        private readonly PlaygroundContext _context;

        public BuilderProvider(PlaygroundContext context)
        {
            _context = context;
        }

        public ProductBuilder AProduct() => new ProductBuilder(_context);
    }
}
