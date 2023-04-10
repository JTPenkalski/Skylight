﻿using System.Collections.Generic;
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
        Task<int> CreateAsync(T entity);

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
        /// <param name="entity">The entity to update.</param>
        Task UpdateAsync(T entity);

        /// <summary>
        /// Deletes an entity of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        Task DeleteAsync(int id);
    }
}