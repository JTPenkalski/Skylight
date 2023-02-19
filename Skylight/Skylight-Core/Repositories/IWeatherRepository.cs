using Skylight.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Manages access to a data source for storing <see cref="Weather"/> entities.
    /// </summary>
    public interface IWeatherRepository
    {
        /// <summary>
        /// Creates a new <see cref="Weather"/> entity in the database.
        /// </summary>
        /// <param name="weather">The entity containing the data to store.</param>
        Task CreateAsync(Weather weather);

        /// <summary>
        /// Deletes a <see cref="Weather"/> entity from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        Task DeleteAsync(int id);

        /// <summary>
        /// Reads a specific <see cref="Weather"/> entity from the database.
        /// </summary>
        /// <param name="id">The ID of the entity to get.</param>
        /// <returns>The specified entity, or null if none was found.</returns>
        Task<Weather?> ReadAsync(int id);

        /// <summary>
        /// Reads all <see cref="Weather"/> entities from the database.
        /// </summary>
        /// <returns>A collection of all the entities.</returns>
        Task<IEnumerable<Weather>> ReadAllAsync();

        /// <summary>
        /// Updates a <see cref="Weather"/> entity in the database.
        /// </summary>
        /// <param name="weather">The entity containing the data to store.</param>
        Task UpdateAsync(Weather weather);
    }
}