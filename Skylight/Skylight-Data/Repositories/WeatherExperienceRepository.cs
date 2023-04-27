using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherExperienceRepository"/>
    public class WeatherExperienceRepository : BaseRepository<WeatherExperience>, IWeatherExperienceRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherExperienceRepository(WeatherExperienceContext context) : base(context) { }
    }
}