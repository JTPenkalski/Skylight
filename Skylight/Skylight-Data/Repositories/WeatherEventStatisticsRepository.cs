using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventStatisticsRepository"/>
    public class WeatherEventStatisticsRepository : BaseRepository<WeatherEventStatistics>, IWeatherEventStatisticsRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherEventStatisticsRepository(WeatherExperienceContext context) : base(context) { }
    }
}