using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventRepository"/>
    public class WeatherEventRepository : BaseRepository<WeatherEvent>, IWeatherEventRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherEventRepository(WeatherExperienceContext context) : base(context) { }
    }
}