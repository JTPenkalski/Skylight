using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.DatabaseContexts;
using Skylight.DatabaseContexts.Factories;
using Skylight.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherService"/>
    public class WeatherService : BaseService, IWeatherService
    {
        /// <inheritdoc cref="BaseService(IWeatherExperienceContextFactory)"/>
        public WeatherService(ILogger<WeatherService> logger, IWeatherExperienceContextFactory contextFactory)
            : base(logger, contextFactory) { }

        /// <inheritdoc cref="IWeatherService.CreateWeatherAsync(Weather)"/>
        public async Task<Weather?> CreateWeatherAsync(Weather weather)
        {
            using WeatherExperienceContext context = await contextFactory.CreateDbContextAsync();

            context.Weather.Add(weather);

            try
            {
                return (await context.SaveChangesAsync() > 0) ? weather : null;
            }
            catch (DbUpdateException)
            {
                return null;
            }
        }

        /// <inheritdoc cref="IWeatherService.DeleteWeatherAsync(int)"/>
        public async Task<bool> DeleteWeatherAsync(int id)
        {
            using WeatherExperienceContext context = await contextFactory.CreateDbContextAsync();

            Weather? weather = await context.Weather.FindAsync(id);
            if (weather is null)
            {
                return false;
            }

            context.Weather.Remove(weather);

            try
            {
                return (await context.SaveChangesAsync()) > 0;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        /// <inheritdoc cref="IWeatherService.GetWeatherAsync(int)"/>
        public async Task<Weather?> GetWeatherAsync(int id)
        {
            using WeatherExperienceContext context = await contextFactory.CreateDbContextAsync();

            return await context.Weather.FindAsync(id);
        }

        /// <inheritdoc cref="IWeatherService.GetWeatherAsync"/>
        public async Task<IEnumerable<Weather>> GetWeatherAsync()
        {
            using WeatherExperienceContext context = await contextFactory.CreateDbContextAsync();

            return await context.Weather.ToListAsync();
        }

        /// <inheritdoc cref="IWeatherService.UpdateWeatherAsync(int, Weather)"/>
        public async Task<bool> UpdateWeatherAsync(int id, Weather weather)
        {
            using WeatherExperienceContext context = await contextFactory.CreateDbContextAsync();

            Weather? entry = await context.Weather.FindAsync(id);
            if (entry is null)
            {
                return false;
            }

            entry = weather;
            context.Weather.Update(entry);

            try
            {
                return (await context.SaveChangesAsync()) > 0;
            }
            catch (DbUpdateConcurrencyException)
            {
                return EntityExists(context.Weather, id);
            }
        }
    }
}