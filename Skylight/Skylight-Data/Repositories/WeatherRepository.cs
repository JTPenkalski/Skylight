using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherRepository"/>
    public class WeatherRepository : BaseRepository<Weather>, IWeatherRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(ILogger{BaseRepository{T}}, WeatherExperienceContext)"/>
        public WeatherRepository(
            ILogger<WeatherRepository> logger,
            WeatherExperienceContext context
        ) : base(logger, context) { }

        public async Task<int> GetWeatherIdByName(string name)
        {
            return (await table.FirstOrDefaultAsync(x => x.Name.ToUpper() == name.ToUpper()))?.Id ?? -1;
        }
    }
}