using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.Weather"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherController : BaseController<Models.Weather, WebModels.Weather>
    {
        /// <summary>
        /// Constructs a new <see cref="WeatherController"/> instance.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public WeatherController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherService service
        ) : base(config, logger, mapper, service) { }
    }
}
