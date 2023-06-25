using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventStatisticsRepository"/>
    public class WeatherEventStatisticsRepository : BaseRepository<WeatherEventStatistics>, IWeatherEventStatisticsRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherEventStatisticsRepository(
            ILogger<WeatherEventStatisticsRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}