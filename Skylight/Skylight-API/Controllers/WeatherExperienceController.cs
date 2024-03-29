﻿using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;
using Skylight.WebModels.Models;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.Models.WeatherExperience"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherExperienceController : BaseController<Models.WeatherExperience, WeatherExperience>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger{BaseController{TModel, TWebModel}}, IMapper, IService{TModel})"/>
        public WeatherExperienceController(
            IConfiguration config,
            ILogger<WeatherExperienceController> logger,
            IMapper mapper,
            IWeatherExperienceService service
        ) : base(config, logger, mapper, service) { }
    }
}