using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Skylight.Controllers
{
    /// <summary>
    /// Represents the shared behavior of all API controllers.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    [ApiController]
    public class BaseController : ControllerBase
    {
        public const string POST_ERROR = "Object creation failed.";

        protected readonly IConfiguration config;
        protected readonly ILogger logger;
        protected readonly IMapper mapper;

        public BaseController(
            IConfiguration config,
            ILogger logger,
            IMapper mapper
        )
        {
            this.config = config;
            this.logger = logger;
            this.mapper = mapper;
        }
    }
}