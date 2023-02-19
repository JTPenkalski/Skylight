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
    [ApiController]
    [ApiVersion(Version.VERSION)]
    public class WeatherController : BaseController
    {
        protected readonly IWeatherService weatherService;

        public WeatherController(
            IConfiguration config,
            ILogger<WeatherController> logger,
            IMapper mapper,
            IWeatherService weatherService
        ) : base(config, logger, mapper)
        {
            this.weatherService = weatherService;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            var response = await weatherService.RemoveWeatherAsync(id);

            return response.Success ? NoContent() : NotFound();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebModels.Weather>>> GetWeatherTypes()
        {
            var response = await weatherService.GetWeatherAsync();

            return response.Success ? Ok(mapper.Map<IEnumerable<Models.Weather>, IEnumerable<WebModels.Weather>>(response.Content!)) : NotFound();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebModels.Weather>> GetWeather(int id)
        {
            var response = await weatherService.GetWeatherAsync(id);

            return response.Success ? Ok(mapper.Map<Models.Weather, WebModels.Weather>(response.Content!)) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult<WebModels.Weather>> PostWeather(WebModels.Weather weather)
        {
            var response = await weatherService.AddWeatherAsync(mapper.Map<WebModels.Weather, Models.Weather>(weather));

            return response.Success
                ? CreatedAtAction($"{nameof(PostWeather)}", new { id = response.Content!.Id }, mapper.Map<Models.Weather, WebModels.Weather>(response.Content))
                : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, WebModels.Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            var response = await weatherService.ModifyWeatherAsync(id, mapper.Map<WebModels.Weather, Models.Weather>(weather));

            return response.Success ? NoContent() : NotFound();
        }
    }
}
