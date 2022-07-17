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
    public class WeatherExperiencesController : ControllerBase
    {
        private readonly WeatherExperienceContext context;

        public WeatherExperiencesController(WeatherExperienceContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherExperience>>> GetWeatherExperiences()
        {
            if (context.WeatherExperiences == null)
            {
                return NotFound();
            }

            return await context.WeatherExperiences.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherExperience>> GetWeatherExperience(int id)
        {
            if (context.WeatherExperiences == null)
            {
                return NotFound();
            }

            var weatherExperience = await context.WeatherExperiences.FindAsync(id);

            if (weatherExperience == null)
            {
                return NotFound();
            }

            return weatherExperience;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeatherExperience(int id, WeatherExperience weatherExperience)
        {
            if (id != weatherExperience.Id)
            {
                return BadRequest();
            }

            // TODO: Actually update the object (use View Models?)
            context.Entry(weatherExperience).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!WeatherExperienceExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<WeatherExperience>> CreateWeatherExperience(WeatherExperience weatherExperience)
        {
            if (context.WeatherExperiences == null)
            {
                return Problem("Entity set 'WeatherExperienceContext.WeatherExperiences' is null.");
            }

            context.WeatherExperiences.Add(weatherExperience);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeatherExperience), new { id = weatherExperience.Id }, weatherExperience);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherExperience(int id)
        {
            if (context.WeatherExperiences == null)
            {
                return NotFound();
            }
            var weatherExperience = await context.WeatherExperiences.FindAsync(id);
            if (weatherExperience == null)
            {
                return NotFound();
            }

            context.WeatherExperiences.Remove(weatherExperience);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherExperienceExists(int id)
        {
            return (context.WeatherExperiences?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
