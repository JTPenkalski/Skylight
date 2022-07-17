using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Skylight.Models;

namespace Skylight.Contexts
{
    public class WeatherExperienceContext : DbContext
    {
        public DbSet<WeatherExperience> WeatherExperiences => Set<WeatherExperience>();
        public DbSet<WeatherEvent> WeatherEvents => Set<WeatherEvent>();
        public DbSet<WeatherAlert> WeatherAlerts => Set<WeatherAlert>();
        public DbSet<WeatherType> WeatherTypes => Set<WeatherType>();
        public DbSet<RiskCategory> RiskCategories => Set<RiskCategory>();
        public DbSet<WeatherAlertType> WeatherAlertTypes => Set<WeatherAlertType>();
        public DbSet<WeatherAlertModifier> WeatherAlertModifiers => Set<WeatherAlertModifier>();
        public DbSet<WeatherEventSeverity> WeatherEventSeverities => Set<WeatherEventSeverity>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<StormTracker> StormTrackers => Set<StormTracker>();
        public DbSet<WeatherEventObservationMethod> WeatherEventObservationMethods => Set<WeatherEventObservationMethod>();

        private readonly IConfiguration config;

        public WeatherExperienceContext
        (
            DbContextOptions<WeatherExperienceContext> contextOptions,
            IConfiguration config
        ) : base(contextOptions)
        {
            this.config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}