using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherExperienceRepository"/>
    public class WeatherExperienceRepository : BaseRepository<WeatherExperience>, IWeatherExperienceRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherExperienceRepository(
            ILogger<WeatherExperienceRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}