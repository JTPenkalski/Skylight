using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Skylight.Configuration.Options;
using Skylight.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Skylight.Contexts
{
    /// <summary>
    /// Represents the database containing all information for Weather Experiences.
    /// </summary>
    public class WeatherExperienceContext : DbContext
    {
        protected readonly DatabaseOptions config;

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

        public WeatherExperienceContext(
            IOptions<DatabaseOptions> config,
            DbContextOptions<WeatherExperienceContext> contextOptions
        ) : base(contextOptions)
        {
            this.config = config.Value;
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            UpdateAuditColumns();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            UpdateAuditColumns();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (config.EnableSensitiveDataLogging)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            // Enum Value Converters
            configurationBuilder.Properties<OutlookProbabilityWeatherType>().HaveConversion<string>();
            configurationBuilder.Properties<WeatherAlertModifierOperation>().HaveConversion<string>();
        }

        protected void UpdateAuditColumns()
        {
            foreach (var entityEntry in ChangeTracker.Entries())
            {
                if (entityEntry.Entity is BaseModel entity)
                {
                    switch (entityEntry.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = DateTime.UtcNow;
                            entity.UpdatedDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            entityEntry.Property(nameof(entity.CreatedDate)).IsModified = false;
                            entity.UpdatedDate = DateTime.UtcNow;
                            break;
                    }
                }
            }
        }
    }
}