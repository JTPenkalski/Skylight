using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="ILocationRepository"/>
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public LocationRepository(
            ILogger<LocationRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }
    }
}