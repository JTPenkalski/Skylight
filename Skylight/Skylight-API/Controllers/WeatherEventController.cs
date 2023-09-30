using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Controllers.Interfaces;
using Skylight.Forms;
using Skylight.Services;
using System.Threading.Tasks;

namespace Skylight.Controllers
{
    /// <summary>
    /// Web API Controller for manipulating <see cref="WebModels.WeatherEvent"/> models.
    /// </summary>
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherEventController : BaseController<Models.WeatherEvent, WebModels.WeatherEvent>, IFormModifiable<WebModels.WeatherEvent>
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
        public async Task<WebModels.FormGuide> GetGuide(WebModels.WeatherEvent model, WebModels.FormGuideContext context)
        {
            await Task.Yield();
            return null!; // Ok(await formDirector.GetGuide(mapper.Map<WebModels.WeatherEvent, Models.WeatherEvent>(model)));
        }
    }
}
