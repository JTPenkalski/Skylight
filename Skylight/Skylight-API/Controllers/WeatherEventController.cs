using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Forms;
using Skylight.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.WeatherEvent"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherEventController : BaseController<Models.WeatherEvent, WebModels.WeatherEvent>
    {
        protected readonly IWeatherEventFormDirector formDirector;

        /// <inheritdoc cref="BaseController{TModel, TWebModel}.BaseController(IConfiguration, ILogger, IMapper, IService{TModel})"/>
        public WeatherEventController(
            IConfiguration config,
            ILogger<WeatherEventController> logger,
            IMapper mapper,
            IWeatherEventService service,
            IWeatherEventFormDirector formDirector
        ) : base(config, logger, mapper, service)
        {
            this.formDirector = formDirector;
        }

        /// <summary>
        /// Gets a form guide based on the current status of the model.
        /// </summary>
        /// <param name="model">The model to base guide validation on.</param>
        /// <returns>A form guide.</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("FormGuide")]
        public async Task<ActionResult<IEnumerable<FormGuide>>> GetGuide(WebModels.WeatherEvent model)
        {
            return Ok(await formDirector.GetGuide(mapper.Map<WebModels.WeatherEvent, Models.WeatherEvent>(model)));
        }
    }
}
