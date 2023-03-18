using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherRepository"/>
    public class WeatherRepository : BaseRepository<Weather>, IWeatherRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherRepository(WeatherExperienceContext context) : base(context) { }
    }
}