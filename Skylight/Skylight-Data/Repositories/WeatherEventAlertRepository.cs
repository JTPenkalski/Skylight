using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventAlertRepository"/>
    public class WeatherEventAlertRepository : BaseRepository<WeatherEventAlert>, IWeatherEventAlertRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherEventAlertRepository(WeatherExperienceContext context) : base(context) { }
    }
}