using Isidoro.PlaygroundBackend.Databuilder.Builders.Abstract;

namespace Isidoro.PlaygroundBackend.Databuilder.Builders.Product
{
    public class ProductBuilder : IEntityBuilder<ProductBuilder, Domain.Product>
    {
        private Domain.Product _entity;
        private bool _didBuild = false;

        public ProductBuilder()
        {
            _entity = new Domain.Product();
        }

        public async Task<Domain.Product> Build()
        {
            var bob = new BuilderProvider();

            if (_entity.Id == Guid.Empty)
            {
                _entity.Id = Guid.NewGuid();
            }

            if (string.IsNullOrEmpty(_entity.Name))
            {
                _entity.Name  = "Product_" + _entity.Id.ToString("N").Substring(0, 5);
            }

            if (string.IsNullOrEmpty(_entity.Description))
            {
                _entity.Description = "Description " + _entity.Name;
            }

            if (_entity.Price is null)
            {
                var random = new Random();
                _entity.Price = Math.Round(random.NextDouble() * (1000 - 0.01) + 0.01, 2);
            }

            _didBuild = true;
            return _entity;
        }

        public async Task<Domain.Product> InsertDataAsync()
        {
            if (!_didBuild)
                await Build();

            return _entity;
        }

        public ProductBuilder WithId(Guid id)
        {
            _entity.Id = id;
            return this;
        }

        public ProductBuilder WithName(string name)
        {
            _entity.Name = name;
            return this;
        }

        public ProductBuilder WithDescription(string description)
        {
            _entity.Description = description;
            return this;
        }

        public ProductBuilder WithPrice(double price)
        {
            _entity.Price = price;
            return this;
        }
    }
}
