using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Manages access to a data source for storing entities.
    /// </summary>
    public interface IRepository<T>
    {
        /// <summary>
        /// Creates an entity of type <typeparamref name="T"/> in the database. 
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The ID of the created entity.</returns>
        int Create(T entity);

        /// <summary>
        /// Reads an entity of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>
        /// <returns>The specified entity, or null if none was found.</returns>
        Task<T?> ReadAsync(int id);

        /// <summary>
        /// Reads all entities of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <returns>A collection of all the entities.</returns>
        Task<IEnumerable<T>> ReadAllAsync();

        /// <summary>
        /// Updates an entity of type <typeparamref name="T"/> in the database.
        /// </summary>
        /// <remarks>
        /// Use this endpoint to perform a soft delete by modifying the delete property on an entity.
        /// </remarks>
        /// <param name="entity">The entity to update.</param>
        /// <returns>True if the entity was updated, false otherwise.</returns>
        bool Update(T entity);

        /// <summary>
        /// Deletes an entity of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <remarks>
        /// This performs a hard delete, meaning the data is physically removed from the database.
        /// This should typically only be done for administrative reasons. Use <see cref="Update(T)"/> to perform soft deletes.
        /// </remarks>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>True if the entity was deleted, false otherwise.</returns>
        Task<bool> Delete(int id);
    }
}