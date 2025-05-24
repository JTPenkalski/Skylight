using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Events;
using Skylight.Domain.Common.Exceptions;
using Skylight.Infrastructure.Identity.Roles;
using Skylight.Infrastructure.Identity.Users;
using System.Reflection;

namespace Skylight.Infrastructure.Data;

public class SkylightDbContext(
	DbContextOptions<SkylightDbContext> options,
	ILogger<SkylightDbContext> logger)
	: IdentityDbContext<User, Role, Guid, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>(options),
	ISkylightDbContext
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

	public DbSet<AlertParameter> AlertParameters => Set<AlertParameter>();

	public DbSet<Zone> Zones => Set<Zone>();

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

	public async Task<T?> FindOptionalAsync<T>(Guid id, CancellationToken cancellationToken = default) where T : BaseEntity
	{
		T? entity = await Set<T>()
			.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

		return entity;
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

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}

	protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
	{
		// Enum Value Converters
		configurationBuilder.Properties<AlertCertainty>().HaveConversion<string>();
		configurationBuilder.Properties<AlertLevel>().HaveConversion<string>();
		configurationBuilder.Properties<AlertMessageType>().HaveConversion<string>();
		configurationBuilder.Properties<AlertResponse>().HaveConversion<string>();
		configurationBuilder.Properties<AlertSeverity>().HaveConversion<string>();
		configurationBuilder.Properties<AlertUrgency>().HaveConversion<string>();
		configurationBuilder.Properties<AlertParameterKey>().HaveConversion<string>();
		configurationBuilder.Properties<AlertThreat>().HaveConversion<string>();
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
