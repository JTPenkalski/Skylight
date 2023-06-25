using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using System;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Unit of Work implementation that uses Entity Framework Core for transaction management.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly WeatherExperienceContext context;

        public string ChangeTrackingStatus
        {
            get
            {
                context.ChangeTracker.DetectChanges();
                return context.ChangeTracker.DebugView.LongView;
            }
        }

        public ILocationRepository Locations { get; }
        public IWeatherRepository Weather { get; }
        public IWeatherAlertRepository WeatherAlerts { get; }
        public IWeatherAlertModifierRepository WeatherAlertModifiers { get; }
        public IWeatherEventRepository WeatherEvents { get; }
        public IWeatherEventAlertRepository WeatherEventAlerts { get; }
        public IWeatherEventStatisticsRepository WeatherEventStatistics { get; }
        public IWeatherExperienceRepository WeatherExperiences { get; }

        protected readonly ILogger logger;

        /// <summary>
        /// Creates a new <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <param name="context">EF Core database context.</param>
        public UnitOfWork(
            ILogger<UnitOfWork> logger,
            WeatherExperienceContext context,
            ILocationRepository location,
            IWeatherRepository weather,
            IWeatherAlertRepository weatherAlerts,
            IWeatherAlertModifierRepository weatherAlertModifiers,
            IWeatherEventRepository weatherEvents,
            IWeatherEventAlertRepository weatherEventAlerts,
            IWeatherEventStatisticsRepository weatherEventStatistics,
            IWeatherExperienceRepository weatherExperiences
        )
        {
            this.logger = logger;
            this.context = context;

            Locations = location;
            Weather = weather;
            WeatherAlerts = weatherAlerts;
            WeatherAlertModifiers = weatherAlertModifiers;
            WeatherEvents = weatherEvents;
            WeatherEventAlerts = weatherEventAlerts;
            WeatherEventStatistics = weatherEventStatistics;
            WeatherExperiences = weatherExperiences;
        }

        public async Task<bool> CommitAsync()
        {
            bool success = true;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("There was a problem updating the database. No changes have been made.\nInner Exception: {ERROR}", ex.Message);
            }

            return success;
        }

        public async Task RollbackAsync()
        {
            await context.DisposeAsync();
        }
    }
}