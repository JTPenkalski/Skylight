using Skylight.Contexts;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Unit of Work implementation that uses Entity Framework Core for transaction management.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly WeatherExperienceContext context;

        public ILocationRepository Locations { get; }
        public IWeatherRepository Weather { get; }
        public IWeatherAlertRepository WeatherAlerts { get; }
        public IWeatherAlertModifierRepository WeatherAlertModifiers { get; }
        public IWeatherEventRepository WeatherEvents { get; }

        /// <summary>
        /// Creates a new <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <param name="context">EF Core database context.</param>
        public UnitOfWork(
            WeatherExperienceContext context,
            ILocationRepository location,
            IWeatherRepository weather,
            IWeatherAlertRepository weatherAlerts,
            IWeatherAlertModifierRepository weatherAlertModifiers,
            IWeatherEventRepository weatherEvents
        )
        {
            this.context = context;

            Locations = location;
            Weather = weather;
            WeatherAlerts = weatherAlerts;
            WeatherAlertModifiers = weatherAlertModifiers;
            WeatherEvents = weatherEvents;
        }

        /// <inheritdoc cref="IUnitOfWork.CommitAsync"/>
        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IUnitOfWork.Rollback"/>
        public async Task RollbackAsync()
        {
            await context.DisposeAsync();
        }
    }
}