namespace Skylight.Contexts.Initializers
{
    /// <summary>
    /// Service for initializing a test database.
    /// </summary>
    public interface IWeatherExperienceContextInitializer
    {
        /// <summary>
        /// Seeds a database with initial data.
        /// </summary>
        void Initialize();
    }
}