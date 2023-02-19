using Skylight.Contexts;
using Skylight.Models;

namespace Skylight.Repositories
{
    public class WeatherRepository : BaseRepository<Weather>, IWeatherRepository
    {
        public WeatherRepository(WeatherExperienceContext context) : base(context) { }
    }
}