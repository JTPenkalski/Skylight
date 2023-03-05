using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherAlertModifierService"/>
    public class WeatherAlertModifierService : BaseService<WeatherAlertModifier>, IWeatherAlertModifierService
    {
        protected override IWeatherAlertModifierRepository Repository => unitOfWork.WeatherAlertModifiers;

        /// <inheritdoc cref="BaseService{T}.BaseService(ILogger, IUnitOfWork)"/>
        public WeatherAlertModifierService(ILogger<WeatherAlertModifierService> logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork) { }
    }
}