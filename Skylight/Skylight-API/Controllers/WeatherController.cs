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
    /// Web API Controller for manipulating <see cref="WebModels.Weather"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherController : BaseController<Models.Weather, WebModels.Weather>
    {
        /// <inheritdoc cref="BaseController{Models.Weather, WebModels.Weather}.BaseController(IConfiguration, ILogger, IMapper, IService{Models.Weather})"/>
        public WeatherController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherService service
        ) : base(config, logger, mapper, service) { }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Post(TWebModel)"/>
        [HttpPost]
        public override async Task<ActionResult<WebModels.Weather>> Post(WebModels.Weather model)
        {
            return await base.Post(model);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Get(int)"/>
        [HttpGet("{id}")]
        public override async Task<ActionResult<WebModels.Weather>> Get(int id)
        {
            return await base.Get(id);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.GetAll"/>
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<WebModels.Weather>>> GetAll()
        {
            return await base.GetAll();
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Put(int, TWebModel)"/>
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(int id, WebModels.Weather model)
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