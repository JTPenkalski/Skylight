using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly WeatherExperienceContext context;

        public WeatherController(WeatherExperienceContext context)
        {
            this.context = context;
        }

        // GET: api/Weather
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Weather>>> GetWeatherTypes()
        {
          if (context.Weather == null)
          {
              return NotFound();
          }
            return await context.Weather.ToListAsync();
        }

        // GET: api/Weather/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Weather>> GetWeather(int id)
        {
          if (context.Weather == null)
          {
              return NotFound();
          }
            var weather = await context.Weather.FindAsync(id);

            if (weather == null)
            {
                return NotFound();
            }

            return weather;
        }

        // PUT: api/Weather/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeather(int id, Weather weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            context.Entry(weather).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Weather
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Weather>> PostWeather(Weather weather)
        {
          if (context.Weather == null)
          {
              return Problem("Entity set 'WeatherExperienceContext.WeatherTypes'  is null.");
          }
            context.Weather.Add(weather);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetWeather", new { id = weather.Id }, weather);
        }

        // DELETE: api/Weather/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeather(int id)
        {
            if (context.Weather == null)
            {
                return NotFound();
            }
            var weather = await context.Weather.FindAsync(id);
            if (weather == null)
            {
                return NotFound();
            }

            context.Weather.Remove(weather);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherExists(int id)
        {
            return (context.Weather?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
