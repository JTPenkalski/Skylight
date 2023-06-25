using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherAlertModifierRepository"/>
    public class WeatherAlertModifierRepository : BaseRepository<WeatherAlertModifier>, IWeatherAlertModifierRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherAlertModifierRepository(
            ILogger<WeatherAlertModifierRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}