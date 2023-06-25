using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherRepository"/>
    public class WeatherRepository : BaseRepository<Weather>, IWeatherRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherRepository(
            ILogger<WeatherRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}