using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.WeatherEvent"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherEventController : BaseController<Models.WeatherEvent, WebModels.WeatherEvent>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public WeatherEventController(
            IConfiguration config,
            ILogger<WeatherEventController> logger,
            IMapper mapper,
            IWeatherEventService service
        ) : base(config, logger, mapper, service) { }
    }
}
