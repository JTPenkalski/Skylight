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

        public IWeatherRepository Weather { get; }
        public IWeatherAlertRepository WeatherAlerts { get; }

        /// <summary>
        /// Creates a new <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <param name="context">EF Core database context.</param>
        public UnitOfWork(
            WeatherExperienceContext context,
            IWeatherRepository weather,
            IWeatherAlertRepository weatherAlerts
        )
        {
            this.context = context;

            Weather = weather;
            WeatherAlerts = weatherAlerts;
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