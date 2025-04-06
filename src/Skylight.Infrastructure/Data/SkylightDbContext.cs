using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Application.Data;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Events;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Infrastructure.Data;

public class SkylightDbContext(ILogger<SkylightDbContext> logger) : DbContext, ISkylightDbContext
{
	public string ChangeTrackingStatus
	{
		get
		{
			ChangeTracker.DetectChanges();
			return ChangeTracker.DebugView.LongView;
		}
	}

	public DbSet<Event> Events => Set<Event>();

	public DbSet<Alert> Alerts => Set<Alert>();

	public DbSet<AlertType> AlertTypes => Set<AlertType>();

	public DbSet<AlertSender> AlertSenders => Set<AlertSender>();

	public DbSet<AlertZone> AlertZones => Set<AlertZone>();

	public async Task<T> FindAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity
	{
		T? entity = await Set<T>()
			.FindAsync([id], cancellationToken);

		return ValidateFoundEntity(id, entity);
	}

	public async Task<T> FindNoTrackingAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity
	{
		T? entity = await Set<T>()
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

		return ValidateFoundEntity(id, entity);
	}

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
			logger.LogError(ex, "An exception was thrown when updating the database, no changes have been made.");
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

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		// Enum Value Converters
		configurationBuilder.Properties<Certainty>().HaveConversion<string>();
		configurationBuilder.Properties<Level>().HaveConversion<string>();
		configurationBuilder.Properties<MessageType>().HaveConversion<string>();
		configurationBuilder.Properties<Response>().HaveConversion<string>();
		configurationBuilder.Properties<Severity>().HaveConversion<string>();
		configurationBuilder.Properties<Urgency>().HaveConversion<string>();
		configurationBuilder.Properties<ZoneType>().HaveConversion<string>();
	}

	protected static T ValidateFoundEntity<T>(Guid id, T? entity) where T : BaseEntity
	{
		if (entity is BaseAuditableEntity auditableEntity)
		{
			EntityNotFoundException.ThrowIfNullOrDeleted(auditableEntity, id);
		}
		else
		{
			EntityNotFoundException.ThrowIfNull(entity, id);
		}

		return entity;
	}
}
