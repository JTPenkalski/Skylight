using Microsoft.EntityFrameworkCore;
using Skylight.Domain.Entities;
using Skylight.Domain.Exceptions;

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
    /// Finds a <typeparamref name="T"/> in the database, throwing an <see cref="EntityNotFoundException"/> if not found.
    /// </summary>
    /// <param name="id">The <see cref="BaseEntity.Id"/> to query for.</param>
    /// <returns>The tracked <typeparamref name="T"/> instance.</returns>
    /// <exception cref="EntityNotFoundException"/>
    Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity;
    
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
