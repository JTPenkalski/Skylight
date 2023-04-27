using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherAlertRepository"/>
    public class WeatherAlertRepository : BaseRepository<WeatherAlert>, IWeatherAlertRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherAlertRepository(WeatherExperienceContext context) : base(context) { }
    }
}