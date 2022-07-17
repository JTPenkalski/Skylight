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
    public class WeatherTypesController : ControllerBase
    {
        private readonly WeatherExperienceContext context;

        public WeatherTypesController(WeatherExperienceContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherType>>> GetWeatherTypes()
        {
            if (context.WeatherTypes == null)
            {
                return NotFound();
            }

            return await context.WeatherTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherType>> GetWeatherType(int id)
        {
            if (context.WeatherTypes == null)
            {
                return NotFound();
            }

            var weatherType = await context.WeatherTypes.FindAsync(id);

            if (weatherType == null)
            {
                return NotFound();
            }

            return weatherType;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWeatherType(int id, WeatherType weatherType)
        {
            if (id != weatherType.Id)
            {
                return BadRequest();
            }

            context.Entry(weatherType).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!WeatherTypeExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<WeatherType>> CreateWeatherType(WeatherType weatherType)
        {
            if (context.WeatherTypes == null)
            {
                return Problem("Entity set 'WeatherExperienceContext.WeatherTypes'  is null.");
            }

            context.WeatherTypes.Add(weatherType);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherType", new { id = weatherType.Id }, weatherType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherType(int id)
        {
            if (context.WeatherTypes == null)
            {
                return NotFound();
            }

            var weatherType = await context.WeatherTypes.FindAsync(id);
            if (weatherType == null)
            {
                return NotFound();
            }

            context.WeatherTypes.Remove(weatherType);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherTypeExists(int id)
        {
            return (context.WeatherTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}