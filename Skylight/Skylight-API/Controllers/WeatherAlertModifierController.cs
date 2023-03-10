﻿using Asp.Versioning;
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
    /// Web API Controller for manipulating <see cref="WebModels.WeatherAlertModifierModifier"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherAlertModifierController : BaseController<Models.WeatherAlertModifier, WebModels.WeatherAlertModifier>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public WeatherAlertModifierController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherAlertModifierService service
        ) : base(config, logger, mapper, service) { }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Post(TWebModel)"/>
        [HttpPost]
        public override async Task<ActionResult<WebModels.WeatherAlertModifier>> Post(WebModels.WeatherAlertModifier model)
        {
            return await base.Post(model);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Get(int)"/>
        [HttpGet("{id}")]
        public override async Task<ActionResult<WebModels.WeatherAlertModifier>> Get(int id)
        {
            return await base.Get(id);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.GetAll"/>
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<WebModels.WeatherAlertModifier>>> GetAll()
        {
            return await base.GetAll();
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Put(int, TWebModel)"/>
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(int id, WebModels.WeatherAlertModifier model)
        {
            return await base.Put(id, model);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Delete(int)"/>
        [HttpDelete("{id}")]
        public override async Task<IActionResult> Delete(int id)
        {
            return await base.Delete(id);
        }
    }
}
