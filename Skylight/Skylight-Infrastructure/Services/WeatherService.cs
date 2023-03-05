using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherService"/>
    public class WeatherService : BaseService<Weather>, IWeatherService
    {
        protected override IWeatherRepository Repository => unitOfWork.Weather;

        /// <inheritdoc cref="BaseService{T}.BaseService(ILogger, IUnitOfWork)"/>
        public WeatherService(ILogger<WeatherService> logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork) { }
    }
}