using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;
using Skylight.WebModels.Models;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.Models.WeatherAlert"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherAlertController : BaseController<Models.WeatherAlert, WeatherAlert>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger{BaseController{TModel, TWebModel}}, IMapper, IService{TModel})"/>
        public WeatherAlertController(
            IConfiguration config,
            ILogger<WeatherAlertController> logger,
            IMapper mapper,
            IWeatherAlertService service
        ) : base(config, logger, mapper, service) { }
    }
}