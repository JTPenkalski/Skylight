using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Skylight.Models;

namespace Skylight.Contexts
{
    /// <summary>
    /// Represents the database containing all information for Weather Experiences.
    /// </summary>
    public class WeatherExperienceContext : DbContext
    {
        public DbSet<WeatherExperience> WeatherExperiences => Set<WeatherExperience>();
        public DbSet<WeatherExperienceParticipant> WeatherExperienceParticipants => Set<WeatherExperienceParticipant>();
        public DbSet<WeatherEvent> WeatherEvents => Set<WeatherEvent>();
        public DbSet<WeatherEventStatistics> WeatherEventStatistics => Set<WeatherEventStatistics>();
        public DbSet<WeatherType> WeatherTypes => Set<WeatherType>();
        public DbSet<WeatherAlert> WeatherAlerts => Set<WeatherAlert>();
        public DbSet<WeatherAlertModifier> WeatherAlertModifiers => Set<WeatherAlertModifier>();
        public DbSet<StormTracker> StormTrackers => Set<StormTracker>();
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<WeatherEventObservationMethod> WeatherEventObservationMethods => Set<WeatherEventObservationMethod>();
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Weather Experience Participant Config
            modelBuilder.Entity<WeatherExperienceParticipant>().HasKey(p => new { p.WeatherExperienceId, p.StormTrackerId });

            // Risk Category Outlook Probability Config
            modelBuilder.Entity<RiskCategory>().OwnsMany(
                r => r.TornadoRisk, p =>
                {
                    p.WithOwner().HasForeignKey("RiskCategoryId");
                    p.Property<int>("Id");
                    p.HasKey("Id");
                }
            );

            modelBuilder.Entity<RiskCategory>().OwnsMany(
                r => r.WindRisk, p =>
                {
                    p.WithOwner().HasForeignKey("RiskCategoryId");
                    p.Property<int>("Id");
                    p.HasKey("Id");
                }
            );

            modelBuilder.Entity<RiskCategory>().OwnsMany(
                r => r.HailRisk, p =>
                {
                    p.WithOwner().HasForeignKey("RiskCategoryId");
                    p.Property<int>("Id");
                    p.HasKey("Id");
                }
            );
        }
    }
}