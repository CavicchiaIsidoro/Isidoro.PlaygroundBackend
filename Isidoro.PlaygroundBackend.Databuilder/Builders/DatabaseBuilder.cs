using Isidoro.PlaygroundBackend.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Isidoro.PlaygroundBackend.Databuilder.Builders
{
    public class DatabaseBuilder
    {
        private readonly DbContextOptions<PlaygroundContext> _options;
        private readonly PlaygroundContext _context;

        public DatabaseBuilder()
        {
            _options = new DbContextOptionsBuilder<PlaygroundContext>()
                .EnableSensitiveDataLogging()
                .UseInMemoryDatabase(databaseName: "PlaygroundTestDb")
                .Options;

            _context = new PlaygroundContext(_options);
        }

        public PlaygroundContext Build()
        {
            return _context;
        }
    }
}
