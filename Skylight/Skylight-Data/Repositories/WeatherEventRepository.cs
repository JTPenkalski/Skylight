using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventRepository"/>
    public class WeatherEventRepository : BaseRepository<WeatherEvent>, IWeatherEventRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherEventRepository(
            ILogger<WeatherEventRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}