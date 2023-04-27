using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="ILocationService"/>
    public class LocationService : BaseService<Location>, ILocationService
    {
        protected override ILocationRepository Repository => unitOfWork.Locations;

        /// <inheritdoc cref="BaseService{T}.BaseService(ILogger, IUnitOfWork)"/>
        public LocationService(ILogger<LocationService> logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork) { }
    }
}