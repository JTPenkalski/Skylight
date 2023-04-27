using Microsoft.Extensions.Logging;
using Skylight.Communication;
using Skylight.Models;
using Skylight.Repositories;
using System.Linq;
using System.Threading.Tasks;

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