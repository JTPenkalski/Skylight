using Skylight.Models;

namespace Skylight.Repositories
{
    /// <summary>
    /// Manages access to a data source for storing <see cref="WeatherAlert"/> entities.
    /// </summary>
    public interface IWeatherAlertRepository : IRepository<WeatherAlert>
    {

    }
}