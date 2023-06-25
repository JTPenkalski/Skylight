using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherAlertRepository"/>
    public class WeatherAlertRepository : BaseRepository<WeatherAlert>, IWeatherAlertRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherAlertRepository(
            ILogger<WeatherAlertRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}