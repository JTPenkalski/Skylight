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

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Post(TWebModel)"/>
        [HttpPost]
        public override async Task<ActionResult<WebModels.WeatherAlert>> Post(WebModels.WeatherAlert model)
        {
            return await base.Post(model);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Get(int)"/>
        [HttpGet("{id}")]
        public override async Task<ActionResult<WebModels.WeatherAlert>> Get(int id)
        {
            return await base.Get(id);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.GetAll"/>
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<WebModels.WeatherAlert>>> GetAll()
        {
            return await base.GetAll();
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Put(int, TWebModel)"/>
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(int id, WebModels.WeatherAlert model)
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