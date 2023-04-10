using Skylight.Models;

namespace Skylight.Repositories
{
    /// <summary>
    /// Manages access to a data source for storing <see cref="WeatherEvent"/> entities.
    /// </summary>
    public interface IWeatherEventRepository : IRepository<WeatherEvent>
    {

    }
}