using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.WeatherAlertModifierModifier"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherAlertModifierController : BaseController<Models.WeatherAlertModifier, WebModels.WeatherAlertModifier>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public WeatherAlertModifierController(
            IConfiguration config,
            ILogger<WeatherAlertModifierController> logger,
            IMapper mapper,
            IWeatherAlertModifierService service
        ) : base(config, logger, mapper, service) { }
    }
}
