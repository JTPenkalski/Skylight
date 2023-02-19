using Skylight.DatabaseContexts.Factories;

namespace Skylight.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IWeatherExperienceContextFactory contextFactory;

        public BaseRepository(IWeatherExperienceContextFactory contextFactory)
        {
            this.contextFactory = contextFactory;
        }
    }
}