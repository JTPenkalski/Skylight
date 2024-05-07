using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Skylight.Application.Configuration;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;

namespace Skylight.Data.Contexts;

internal class SkylightContext(
    ILogger<SkylightContext> logger,
    IOptions<DatabaseOptions> config,
    DbContextOptions<SkylightContext> contextOptions
) : DbContext(contextOptions), ISkylightContext
{
    public string ChangeTrackingStatus
    {
        get
        {
            ChangeTracker.DetectChanges();
            return ChangeTracker.DebugView.LongView;
        }
    }

    public DbSet<Location> Locations => Set<Location>();

    public DbSet<StormTracker> StormTrackers => Set<StormTracker>();

    public DbSet<Weather> Weather => Set<Weather>();

    public DbSet<WeatherAlert> WeatherAlerts => Set<WeatherAlert>();

    public DbSet<WeatherAlertModifier> WeatherAlertModifiers => Set<WeatherAlertModifier>();

    public DbSet<WeatherEvent> WeatherEvents => Set<WeatherEvent>();

    public DbSet<WeatherIncident> WeatherIncidents => Set<WeatherIncident>();

    public async Task<bool> CommitAsync(CancellationToken cancellationToken = default)
    {
        bool success = true;

        try
        {
            await SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            success = false;
            logger.LogError("There was a problem updating the database, no changes have been made. Inner Exception: {ERROR}", ex.Message);
        }

        return success;
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await DisposeAsync();
    }

    public async Task ResetAsync(CancellationToken cancellationToken = default)
    {
        await Database.EnsureDeletedAsync(cancellationToken);
        await Database.EnsureCreatedAsync(cancellationToken);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (config.Value.EnableSensitiveDataLogging)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        // Enum Value Converters
        configurationBuilder.Properties<ParticipationMethod>().HaveConversion<string>();
    }
}
