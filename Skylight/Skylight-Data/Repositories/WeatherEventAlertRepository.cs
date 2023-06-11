using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventAlertRepository"/>
    public class WeatherEventAlertRepository : BaseRepository<WeatherEventAlert>, IWeatherEventAlertRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherEventAlertRepository(
            ILogger<WeatherEventAlertRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}