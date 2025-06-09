namespace Isidoro.PlaygroundBackend.Databuilder.Builders.Abstract
{
    public class DatabaseFixture : IDisposable
    {
        public DatabaseBuilder DatabaseBulder { get; set; }

        public DatabaseFixture()
        {
            DatabaseBulder = new DatabaseBuilder();
        }

        public void Dispose()
        {
            DatabaseBulder = null!;
        }
    }
}
