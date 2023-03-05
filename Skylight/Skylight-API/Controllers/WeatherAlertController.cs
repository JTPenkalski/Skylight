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
    public class WeatherAlertController : BaseController<Models.WeatherAlert, WebModels.WeatherAlert>
    {
        public WeatherAlertController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherAlertService service
        ) : base(config, logger, mapper, service) { }
    }
}
