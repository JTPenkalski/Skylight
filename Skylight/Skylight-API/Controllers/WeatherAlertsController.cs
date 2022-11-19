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
    public class WeatherAlertsController : ControllerBase
    {
        private readonly WeatherExperienceContext context;

        public WeatherAlertsController(WeatherExperienceContext context)
        {
            this.context = context;
        }

        // GET: api/WeatherAlerts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherAlert>>> GetWeatherAlerts()
        {
            if (context.WeatherAlerts is null)
            {
                return NotFound();
            }

            return await context.WeatherAlerts.ToListAsync();
        }

        // GET: api/WeatherAlerts/n
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherAlert>> GetWeatherAlert(int id)
        {
            if (context.WeatherAlerts is null)
            {
                return NotFound();
            }

            WeatherAlert? weatherAlert = await context.WeatherAlerts.FindAsync(id);

            if (weatherAlert is null)
            {
                return NotFound();
            }

            return weatherAlert;
        }

        // PUT: api/WeatherAlerts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeatherAlert(int id, WeatherAlert weatherAlert)
        {
            if (id != weatherAlert.Id)
            {
                return BadRequest();
            }

            context.Entry(weatherAlert).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherAlertExists(id))
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

        // POST: api/WeatherAlerts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<WeatherAlert>> PostWeatherAlert(WeatherAlert weatherAlert)
        {
            if (context.WeatherAlerts == null)
            {
                return Problem("Entity set 'WeatherExperienceContext.WeatherAlerts'  is null.");
            }
            context.WeatherAlerts.Add(weatherAlert);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetWeatherAlert", new { id = weatherAlert.Id }, weatherAlert);
        }

        // DELETE: api/WeatherAlerts/n
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWeatherAlert(int id)
        {
            if (context.WeatherAlerts is null)
            {
                return NotFound();
            }

            WeatherAlert? weatherAlert = await context.WeatherAlerts.FindAsync(id);

            if (weatherAlert is null)
            {
                return NotFound();
            }

            context.WeatherAlerts.Remove(weatherAlert);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool WeatherAlertExists(int id)
        {
            return (context.WeatherAlerts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
