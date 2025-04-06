using Microsoft.EntityFrameworkCore;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Events;

namespace Skylight.Application.Data;

/// <summary>
/// Represents the core database entities persisted in the application.
/// </summary>
public interface ISkylightDbContext
{
	string ChangeTrackingStatus { get; }

	DbSet<Event> Events { get; }

	DbSet<Alert> Alerts { get; }

	DbSet<AlertType> AlertTypes { get; }

	DbSet<AlertSender> AlertSenders { get; }

	DbSet<AlertZone> AlertZones { get; }

	/// <summary>
	/// Finds a <typeparamref name="T"/> in the database, throwing an <see cref="EntityNotFoundException"/> if not found.
	/// </summary>
	/// <param name="id">The <see cref="BaseEntity.Id"/> to query for.</param>
	/// <returns>The tracked <typeparamref name="T"/> instance.</returns>
	/// <exception cref="EntityNotFoundException"/>
	Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity;

	/// <summary>
	/// Finds a <typeparamref name="T"/> in the database, throwing an <see cref="EntityNotFoundException"/> if not found.
	/// Does not track the found <typeparamref name="T"/>.
	/// </summary>
	/// <param name="id">The <see cref="BaseEntity.Id"/> to query for.</param>
	/// <returns>The tracked <typeparamref name="T"/> instance.</returns>
	/// <exception cref="EntityNotFoundException"/>
	Task<T> FindNoTrackingAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity;

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
