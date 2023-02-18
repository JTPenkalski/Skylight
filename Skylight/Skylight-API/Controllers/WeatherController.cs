using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Services;

namespace Skylight.Controllers
{
    [Route($"api/{Version.VERSION}/[controller]")]
    [ApiController]
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WebModels.Weather>>> GetWeatherTypes()
        {
            IEnumerable<Models.Weather> weather = await weatherService.GetWeatherAsync();

            // TODO: Map to IEnumerable<WebModels.Weather>
            return weather.Any() ? NotFound() : Ok(weather);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WebModels.Weather>> GetWeather(int id)
        {
            Models.Weather? weather = await weatherService.GetWeatherAsync(id);

            return weather is null ? NotFound() : Ok(mapper.Map<Models.Weather, WebModels.Weather>(weather));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, WebModels.Weather weather)
        {
            //if (id != weather.Id)
            //{
            //    return BadRequest();
            //}

            bool updated = await weatherService.UpdateWeatherAsync(id, mapper.Map<WebModels.Weather, Models.Weather>(weather));

            return updated ? NotFound() : NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<WebModels.Weather>> PostWeather(WebModels.Weather weather)
        {
            Models.Weather? createdWeather = await weatherService.CreateWeatherAsync(mapper.Map<WebModels.Weather, Models.Weather>(weather));

            return createdWeather is null
                ? Problem(POST_ERROR)
                : CreatedAtAction("PostWeather", new { id = createdWeather.Id }, mapper.Map<Models.Weather, WebModels.Weather>(createdWeather));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            bool deleted = await weatherService.DeleteWeatherAsync(id);

            return deleted ? NotFound() : NoContent();
        }
    }
}
