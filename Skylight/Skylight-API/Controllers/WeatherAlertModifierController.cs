using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherAlertModifierController : BaseController<Models.WeatherAlertModifier, WebModels.WeatherAlertModifier>
    {
        public WeatherAlertModifierController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherAlertModifierService service
        ) : base(config, logger, mapper, service) { }
    }
}
