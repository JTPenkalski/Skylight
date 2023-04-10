using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherEventService"/>
    public class WeatherEventService : BaseService<WeatherEvent>, IWeatherEventService
    {
        protected override IWeatherEventRepository Repository => unitOfWork.WeatherEvents;

        /// <inheritdoc cref="BaseService{T}.BaseService(ILogger, IUnitOfWork)"/>
        public WeatherEventService(ILogger<WeatherEventService> logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork) { }
    }
}