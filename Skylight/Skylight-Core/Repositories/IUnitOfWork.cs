using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Provides transaction management services when performing database operations.
    /// </summary>
    public interface IUnitOfWork
    {
        string ChangeTrackingStatus { get; }
        ILocationRepository Locations { get; }
        IWeatherRepository Weather { get; }
        IWeatherAlertRepository WeatherAlerts { get; }
        IWeatherAlertModifierRepository WeatherAlertModifiers { get; }
        IWeatherEventRepository WeatherEvents { get; }
        IWeatherEventAlertRepository WeatherEventAlerts { get; }
        IWeatherEventStatisticsRepository WeatherEventStatistics { get; }
        IWeatherExperienceRepository WeatherExperiences { get; }

        /// <summary>
        /// Saves all changes in the current transaction.
        /// Either all changes are applied, or none of them are.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Cancels all changes in the current transaction.
        /// </summary>
        Task RollbackAsync();
    }
}