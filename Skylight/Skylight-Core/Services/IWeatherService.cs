using Skylight.Communication;
using Skylight.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Services
{
    /// <summary>
    /// Serves as a repository for interacting with <see cref="Weather"/> entities in the database.
    /// </summary>
    public interface IWeatherService
    {
        /// <summary>
        /// Creates a new <see cref="Weather"/> entity in the database.
        /// </summary>
        /// <param name="weather">The complete <see cref="Weather"/> entity.</param>
        /// <returns>A model of the created <see cref="Weather"/> entity, or null if none was created.</returns>
        Task<ServiceResponse<Weather>> AddWeatherAsync(Weather weather);

        /// <summary>
        /// Deletes a specific <see cref="Weather"/> entity from the database.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Weather"/> entity.</param>
        /// <returns>A boolean indicating if the entity was successfully deleted or not.</returns>
        Task<ServiceResponse<Weather>> RemoveWeatherAsync(int id);

        /// <summary>
        /// Gets a specific <see cref="Weather"/> entity from the database.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Weather"/> entity.</param>
        /// <returns>A model of the specified <see cref="Weather"/> entity, or null if none exists.</returns>
        Task<ServiceResponse<Weather>> GetWeatherAsync(int id);

        /// <summary>
        /// Gets all Weather entities from the database.
        /// </summary>
        /// <returns>An <see cref="ICollection{T}"/> of all <see cref="Weather"/> entities.</returns>
        Task<ServiceResponse<IEnumerable<Weather>>> GetWeatherAsync();

        /// <summary>
        /// Updates a specific <see cref="Weather"/> entity in the database.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Weather"/> entity.</param>
        /// <param name="weather">The complete <see cref="Weather"/> entity with updated information.</param>
        /// /// <returns>A boolean indicating if the entity was successfully updated or not.</returns>
        Task<ServiceResponse<Weather>> ModifyWeatherAsync(int id, Weather weather);
    }
}