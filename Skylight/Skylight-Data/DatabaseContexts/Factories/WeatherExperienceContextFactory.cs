using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.DatabaseContexts.Initializers;
using System;

namespace Skylight.DatabaseContexts.Factories
{
    /// <inheritdoc cref="IWeatherExperienceContextFactory"/>
    public class WeatherExperienceContextFactory : IWeatherExperienceContextFactory
    {
        /// <inheritdoc cref="IWeatherExperienceContextFactory.Context"/>
        public WeatherExperienceContext Context => context ?? CreateDbContext();
        
        protected readonly IConfiguration config;
        protected readonly ILogger logger;

        protected WeatherExperienceContext? context;

        /// <summary>
        /// Constructs a new <see cref="WeatherExperienceContextFactory"/> instance.
        /// </summary>
        /// <param name="config">Configuration settings.</param>
        public WeatherExperienceContextFactory(IConfiguration config, ILogger<WeatherExperienceContextFactory> logger)
        {
            this.config = config;
            this.logger = logger;
        }

        /// <inheritdoc cref="IWeatherExperienceContextFactory.InitializeTestDatabase(WeatherExperienceContext)"/>
        public void InitializeTestDatabase()
        {
            WeatherExperienceContext context = CreateDbContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            WeatherExperienceContextInitializer.Initialize(context);
        }

        /// <inheritdoc cref="IDbContextFactory{TContext}"/>
        public WeatherExperienceContext CreateDbContext()
        {
            if (context is null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<WeatherExperienceContext>();

                string? connectionString = config.GetConnectionString("SQL_Server");
                if (connectionString is null)
                    throw new InvalidOperationException($"The connection string for {nameof(WeatherExperienceContext)} is null.");

                optionsBuilder.UseSqlServer(connectionString);

                context = new WeatherExperienceContext(optionsBuilder.Options);
            }

            return context;
        }
    }
}
