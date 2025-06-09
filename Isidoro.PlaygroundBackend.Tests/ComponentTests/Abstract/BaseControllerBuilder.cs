using Isidoro.PlaygroundBackend.Infrastructure;

namespace Isidoro.PlaygroundBackend.Tests.ComponentTests.Abstract
{
    public abstract class BaseControllerBuilder
    {
        protected readonly PlaygroundContext _context;

        public BaseControllerBuilder(PlaygroundContext context)
        {
            _context = context;
        }
    }
}
