using Microsoft.EntityFrameworkCore;

namespace Skylight.DatabaseContexts.Factories
{
    // TODO: Can this be refactored to use default dependency injection? This would prevent having to call Dispose() every time in the service layer.

    /// <summary>
    /// Manages the creation of new instances of a <see cref="WeatherExperienceContext"/>.
    /// Only one context instance will exist per service scope.
    /// </summary>
    public interface IWeatherExperienceContextFactory : IDbContextFactory<WeatherExperienceContext>
    {
        /// <summary>
        /// The instance of the context.
        /// </summary>
        WeatherExperienceContext Context { get; }

        /// <summary>
        /// Uses an Initializer class to seed a test database with data. Does not use the Migrations API.
        /// </summary>
        void InitializeTestDatabase();
    }
}