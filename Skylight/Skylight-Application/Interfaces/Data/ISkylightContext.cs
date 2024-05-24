using Microsoft.EntityFrameworkCore;
using Skylight.Domain.Entities;

namespace Skylight.Application.Interfaces.Data;

/// <summary>
/// Represents the core database entities persisted in the application.
/// </summary>
public interface ISkylightContext
{
    string ChangeTrackingStatus { get; }

    DbSet<Location> Locations { get; }

    DbSet<StormTracker> StormTrackers { get; }

    DbSet<Weather> Weather { get; }

    DbSet<WeatherAlert> WeatherAlerts { get; }

    DbSet<WeatherAlertModifier> WeatherAlertModifiers { get; }

    DbSet<WeatherEvent> WeatherEvents { get; }

    /// <summary>
    /// Saves all changes in the current transaction.
    /// </summary>
    /// <returns>True if the operation was successful, false otherwise.</returns>
    Task<bool> CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Cancels all changes in the current transaction.
    /// </summary>
    Task RollbackAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets all data in the database.
    /// </summary>
    Task ResetAsync(CancellationToken cancellationToken = default);
}
