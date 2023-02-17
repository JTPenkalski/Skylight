using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skylight.DatabaseContexts.Initializers;
using System;

namespace Skylight.DatabaseContexts.Factories
{
    /// <inheritdoc cref="IWeatherExperienceContextFactory"/>
    public class WeatherExperienceContextFactory : IWeatherExperienceContextFactory
    {
        protected readonly IConfiguration config;

        /// <summary>
        /// Constructs a new <see cref="WeatherExperienceContextFactory"/> instance.
        /// </summary>
        /// <param name="config">Configuration settings.</param>
        public WeatherExperienceContextFactory(IConfiguration config)
        {
            this.config = config;
        }

        /// <inheritdoc cref="IWeatherExperienceContextFactory.InitializeTestDatabase(WeatherExperienceContext)"/>
        public void InitializeTestDatabase(WeatherExperienceContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            WeatherExperienceContextInitializer.Initialize(context);
        }

        /// <inheritdoc cref="IDbContextFactory{TContext}"/>
        public WeatherExperienceContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherExperienceContext>();

            string? connectionString = config.GetConnectionString("SQL_Server");
            if (connectionString is null)
                throw new InvalidOperationException($"The connection string for {nameof(WeatherExperienceContext)} is null.");

            optionsBuilder.UseSqlServer(connectionString);

            return new WeatherExperienceContext(optionsBuilder.Options);
        }
    }
}
