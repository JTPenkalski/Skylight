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
    /// Web API Controller for manipulating <see cref="WebModels.Models.Location"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class LocationController : BaseController<Models.Location, Location>
    {
        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public LocationController(
            IConfiguration config,
            ILogger<LocationController> logger,
            IMapper mapper,
            ILocationService service
        ) : base(config, logger, mapper, service) { }
    }
}
