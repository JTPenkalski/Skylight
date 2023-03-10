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
    /// Web API Controller for manipulating <see cref="WebModels.Location"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class LocationController : BaseController<Models.Location, WebModels.Location>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public LocationController(
            IConfiguration config,
            ILogger<LocationController> logger,
            IMapper mapper,
            ILocationService service
        ) : base(config, logger, mapper, service) { }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Post(TWebModel)"/>
        [HttpPost]
        public override async Task<ActionResult<WebModels.Location>> Post(WebModels.Location model)
        {
            return await base.Post(model);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Get(int)"/>
        [HttpGet("{id}")]
        public override async Task<ActionResult<WebModels.Location>> Get(int id)
        {
            return await base.Get(id);
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.GetAll"/>
        [HttpGet]
        public override async Task<ActionResult<IEnumerable<WebModels.Location>>> GetAll()
        {
            return await base.GetAll();
        }

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.Put(int, TWebModel)"/>
        [HttpPut("{id}")]
        public override async Task<IActionResult> Put(int id, WebModels.Location model)
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
