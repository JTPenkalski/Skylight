using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherAlertModifierRepository"/>
    public class WeatherAlertModifierRepository : BaseRepository<WeatherAlertModifier>, IWeatherAlertModifierRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherAlertModifierRepository(WeatherExperienceContext context) : base(context) { }
    }
}