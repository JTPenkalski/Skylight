using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.WeatherAlert"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherAlertController : BaseController<Models.WeatherAlert, WebModels.WeatherAlert>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public WeatherAlertController(
            IConfiguration config,
            ILogger<WeatherAlertController> logger,
            IMapper mapper,
            IWeatherAlertService service
        ) : base(config, logger, mapper, service) { }
    }
}