using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherExperienceService"/>
    public class WeatherExperienceService : BaseService<WeatherExperience>, IWeatherExperienceService
    {
        protected override IWeatherExperienceRepository Repository => unitOfWork.WeatherExperiences;

        /// <inheritdoc cref="BaseService{T}.BaseService(ILogger, IUnitOfWork)"/>
        public WeatherExperienceService(ILogger<WeatherExperienceService> logger, IUnitOfWork unitOfWork)
            : base(logger, unitOfWork) { }
    }
}