using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Controllers.Interfaces;
using Skylight.Forms.Directors;
using Skylight.Services;
using Skylight.WebModels.Forms;
using Skylight.WebModels.Models;
using System.Threading.Tasks;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WeatherEvent"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherEventController : BaseController<Models.WeatherEvent, WeatherEvent>, IFormModifiable<WeatherEvent, WeatherEventFormGuide>
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

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("FormGuide")]
        public async Task<ActionResult<WeatherEventFormGuide>> GetFormGuide(FormGuideRequest<WeatherEvent> request)
        {
            Forms.Guides.WeatherEventFormGuide result = await formDirector.GetGuideAsync(
                mapper.Map<WeatherEvent, Models.WeatherEvent>(request.Model),
                mapper.Map<FormGuideContext, Forms.FormGuideContext>(request.Context)
            );

            WeatherEventFormGuide apiResult = mapper.Map<Forms.Guides.WeatherEventFormGuide, WeatherEventFormGuide>(result);

            return Ok(apiResult);
        }
    }
}
