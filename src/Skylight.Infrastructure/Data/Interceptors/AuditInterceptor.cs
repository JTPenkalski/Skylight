using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Skylight.Application.Common.Identity;
using Skylight.Domain.Common.Entities;

namespace Skylight.Infrastructure.Data.Interceptors;

/// <summary>
/// Sets the audit columns of all updated <see cref="BaseAuditableEntity"/> records.
/// </summary>
public class AuditInterceptor(
	TimeProvider timeProvider,
	ICurrentUserService currentUserService)
	: SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		UpdateAuditColumns(eventData.Context);

		return base.SavingChanges(eventData, result);
	}

	public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		UpdateAuditColumns(eventData.Context);

		return await base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	internal virtual void UpdateAuditColumns(DbContext? context)
	{
		if (context is null) return;

		var updatedEntities = context.ChangeTracker.Entries<IAuditable>()
			.Where(HasEntityUpdated);

		foreach (EntityEntry<IAuditable> entry in updatedEntities)
		{
			DateTimeOffset utcNow = timeProvider.GetUtcNow();
			Guid userId = currentUserService.GetCurrentUserId();

			if (entry.State == EntityState.Added)
			{
				entry.Entity.CreatedBy = userId;
				entry.Entity.CreatedOn = utcNow;
			}
			else if (entry.State == EntityState.Deleted)
			{
				entry.Entity.DeletedBy = userId;
				entry.Entity.DeletedOn = utcNow;
			}

			entry.Entity.ModifiedBy = userId;
			entry.Entity.ModifiedOn = utcNow;
		}
	}

	internal virtual bool HasEntityUpdated(EntityEntry entry)
	{
		bool isTouched = entry.State is EntityState.Added or EntityState.Modified;
		bool isOwnedEntityTouched = entry.References.Any(r =>
			r.TargetEntry is not null &&
			r.TargetEntry.Metadata.IsOwned() &&
			r.TargetEntry.State is EntityState.Added or EntityState.Modified);

		return isTouched || isOwnedEntityTouched;
	}
}
