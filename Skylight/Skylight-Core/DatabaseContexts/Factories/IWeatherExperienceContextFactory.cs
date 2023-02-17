using Microsoft.EntityFrameworkCore;

namespace Skylight.DatabaseContexts.Factories
{
    /// <summary>
    /// Manages the creation of new instances of a <see cref="WeatherExperienceContext"/>.
    /// </summary>
    public interface IWeatherExperienceContextFactory : IDbContextFactory<WeatherExperienceContext>
    {
        /// <summary>
        /// Uses an Initializer class to seed a test database with data. Does not use the Migrations API.
        /// </summary>
        /// <param name="context">The DbContext to initialize with data.</param>
        void InitializeTestDatabase(WeatherExperienceContext context);
    }
}