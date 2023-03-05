using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherAlertService"/>
    public class WeatherAlertService : BaseService<WeatherAlert>, IWeatherAlertService
    {
        protected override IWeatherAlertRepository Repository => unitOfWork.WeatherAlerts;

        /// <inheritdoc cref="BaseService{T}.BaseService(ILogger, IUnitOfWork, IRepository{T})"/>
        public WeatherAlertService(ILogger<WeatherAlertService> logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork) { }
    }
}