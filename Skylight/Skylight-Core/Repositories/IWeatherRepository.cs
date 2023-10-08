using Skylight.Models;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Manages access to a data source for storing <see cref="Weather"/> entities.
    /// </summary>
    public interface IWeatherRepository : IRepository<Weather>
    {
        /// <summary>
        /// Gets the ID of a weather type by its name.
        /// Case insensitive.
        /// </summary>
        /// <param name="name">The name of the weather.</param>
        /// <returns>An integer ID, or -1 if that name was not found.</returns>
        Task<int> GetWeatherIdByName(string name);
    }
}