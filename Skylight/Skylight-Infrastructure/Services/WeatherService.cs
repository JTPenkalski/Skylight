using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Repositories;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherService"/>
    public class WeatherService : BaseService<Weather>, IWeatherService
    {
        /// Constructs a new <see cref="WeatherService"/> instance.
        public WeatherService(ILogger<WeatherService> logger, IUnitOfWork unitOfWork, IWeatherRepository repository)
            : base(logger, unitOfWork, repository) { }
    }
}