using Microsoft.EntityFrameworkCore;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Events;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Application.Common.Data;

/// <summary>
/// Represents the core database entities persisted in the application.
/// </summary>
public interface ISkylightDbContext : IDisposable
{
	string ChangeTrackingStatus { get; }

	DbSet<Event> Events { get; }

	DbSet<Alert> Alerts { get; }

	DbSet<AlertType> AlertTypes { get; }

	DbSet<AlertSender> AlertSenders { get; }

	DbSet<AlertParameter> AlertParameters { get; }

	DbSet<Zone> Zones { get; }

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
	/// Finds an optional <typeparamref name="T"/> in the database.
	/// </summary>
	/// <param name="id">The <see cref="BaseEntity.Id"/> to query for.</param>
	/// <returns>The tracked <typeparamref name="T"/> instance, or null if not found.</returns>
	Task<T?> FindOptionalAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity;

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
