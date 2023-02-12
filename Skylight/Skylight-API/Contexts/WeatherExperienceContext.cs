using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skylight.Attributes.Database;
using Skylight.Models;
using System;
using System.Linq;
using System.Reflection;

namespace Skylight.Contexts
{
    /// <summary>
    /// Represents the database containing all information for Weather Experiences.
    /// </summary>
    public class WeatherExperienceContext : DbContext
    {
        public DbSet<WeatherExperience> WeatherExperiences => Set<WeatherExperience>();
        public DbSet<WeatherExperienceParticipant> WeatherExperienceParticipants => Set<WeatherExperienceParticipant>();
        public DbSet<StormTracker> StormTrackers => Set<StormTracker>();
        public DbSet<WeatherEventObservationMethod> WeatherEventObservationMethods => Set<WeatherEventObservationMethod>();
        public DbSet<WeatherEvent> WeatherEvents => Set<WeatherEvent>();
        public DbSet<WeatherEventAlert> WeatherEventAlerts => Set<WeatherEventAlert>();
        public DbSet<WeatherAlert> WeatherAlerts => Set<WeatherAlert>();
        public DbSet<WeatherAlertModifier> WeatherAlertModifiers => Set<WeatherAlertModifier>();
        public DbSet<Weather> Weather => Set<Weather>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<WeatherEventStatistics> WeatherEventStatistics => Set<WeatherEventStatistics>();
        public DbSet<RiskCategory> RiskCategories => Set<RiskCategory>();

        private readonly IConfiguration config;

        public WeatherExperienceContext
        (
            DbContextOptions<WeatherExperienceContext> contextOptions,
            IConfiguration config
        ) : base(contextOptions)
        {
            this.config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Enum Value Converters
            configurationBuilder.Properties<OutlookProbabilityWeatherType>().HaveConversion<string>();
            configurationBuilder.Properties<WeatherAlertModifierOperation>().HaveConversion<string>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            CreateCompositePrimaryKeys(modelBuilder);
        }

        protected virtual void CreateCompositePrimaryKeys(ModelBuilder modelBuilder)
        {
            // Determine the types of all the models used in this DbContext
            var modelTypes = GetType().GetProperties(
                    BindingFlags.Public |
                    BindingFlags.Instance |
                    BindingFlags.GetProperty
                )
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.PropertyType.GetGenericArguments()[0]);

            // Retrieve all properties that are marked with a CompositeKeyAttribute from the models used in this DbContext
            var compositeKeys = modelTypes
                .SelectMany(t => t.GetProperties(
                    BindingFlags.Public |
                    BindingFlags.NonPublic |
                    BindingFlags.Instance |
                    BindingFlags.GetProperty |
                    BindingFlags.SetProperty
                ))
                .Where(p => p.GetCustomAttribute<CompositeKeyAttribute>() is not null)
                .GroupBy(p => p.DeclaringType!, p => p.Name);

            // Configure the primary key value of any entities with composite keys
            foreach (IGrouping<Type, string> compositeKey in compositeKeys)
            {
                // Track the names of the properties that contribute to this entity's primary key
                int compositeKeyNamesAdded = 0;
                string[] compositeKeyNames = new string[compositeKeys.Count()];

                // Get the names of all properties for this type
                foreach (string propertyName in compositeKey)
                {
                    // If the property name is already an explicit ID, use the property name as is
                    // Otherwise, use the name of the shadow property that holds the ID value
                    compositeKeyNames[compositeKeyNamesAdded++] = (propertyName[^2..].ToUpper() == "ID")
                        ? propertyName
                        : $"{propertyName}Id";
                }

                // Manually set this entity's composite primary key
                modelBuilder.Entity(compositeKey.Key).HasKey(compositeKeyNames);
            }
        }
    }
}