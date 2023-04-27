using Skylight.Models;

namespace Skylight.Repositories
{
    /// <summary>
    /// Manages access to a data source for storing <see cref="Weather"/> entities.
    /// </summary>
    public interface IWeatherRepository : IRepository<Weather>
    {

    }
}