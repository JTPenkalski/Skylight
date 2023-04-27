using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.WeatherExperience"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherExperienceController : BaseController<Models.WeatherExperience, WebModels.WeatherExperience>
    {
        /// <inheritdoc cref="BaseController{Models.WeatherExperience, WebModels.WeatherExperience}.BaseController(IConfiguration, ILogger, IMapper, IService{Models.WeatherExperience})"/>
        public WeatherExperienceController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherExperienceService service
        ) : base(config, logger, mapper, service) { }
    }
}