using Skylight.Contexts;
using Skylight.Models;
using System;
using System.Collections.Generic;
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

        /// <summary>
        /// Creates a new <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <param name="context">EF Core database context.</param>
        public UnitOfWork(WeatherExperienceContext context)
        { 
            this.context = context;

            Weather = new WeatherRepository(context);
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