using Microsoft.EntityFrameworkCore;
using Skylight.DatabaseContexts;
using Skylight.DatabaseContexts.Factories;
using Skylight.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    public class WeatherRepository : BaseRepository, IWeatherRepository
    {
        public WeatherRepository(IWeatherExperienceContextFactory contextFactory)
            : base(contextFactory) { }

        public async Task CreateAsync(Weather weather)
        {
            await contextFactory.Context.Weather.AddAsync(weather);
        }

        public async Task DeleteAsync(int id)
        {
            Weather? weather = await contextFactory.Context.Weather.FindAsync(id);
            if (weather is not null)
            {
                contextFactory.Context.Weather.Remove(weather);
            }
        }

        public async Task<IEnumerable<Weather>> ReadAllAsync()
        {
            return await contextFactory.Context.Weather.ToListAsync();
        }

        public async Task<Weather?> ReadAsync(int id)
        {
            return await contextFactory.Context.Weather.FindAsync(id);
        }

        public async Task UpdateAsync(Weather weather)
        {
            Weather? existing = await contextFactory.Context.Weather.FindAsync(weather.Id);
            if (existing is not null)
            {
                contextFactory.Context.Weather.Update(weather);
            }
        }
    }
}