using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.Weather"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherController : BaseController<Models.Weather, WebModels.Weather>
    {
        /// <inheritdoc cref="BaseController{Models.Weather, WebModels.Weather}.BaseController(IConfiguration, ILogger, IMapper, IService{Models.Weather})"/>
        public WeatherController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherService service
        ) : base(config, logger, mapper, service) { }
    }
}