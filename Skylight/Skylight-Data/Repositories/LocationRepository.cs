using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="ILocationRepository"/>
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public LocationRepository(WeatherExperienceContext context) : base(context) { }
    }
}