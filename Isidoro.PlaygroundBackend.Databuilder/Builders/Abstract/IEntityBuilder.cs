using Isidoro.PlaygroundBackend.Domain.Abstract;

namespace Isidoro.PlaygroundBackend.Databuilder.Builders.Abstract
{
    public interface IEntityBuilder<TBuilder, TEntity>
        where TBuilder : IEntityBuilder<TBuilder, TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// Returns the generated entity, build (if not already done) and insert the entity and all linked entities into the database.
        /// </summary>
        /// <returns>The entity</returns>
        Task<TEntity> InsertDataAsync();

        /// <summary>
        /// Returns the generated entity.
        /// Checks all mandatory fields.
        /// <para>Does not created anything in the database.</para>
        /// </summary>
        Task<TEntity> Build();

        TBuilder WithId(Guid id);
    }
}
