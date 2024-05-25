using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Skylight.Domain.Entities;

namespace Skylight.Data.Interceptors;

/// <summary>
/// Sets the audit columns of all updated <see cref="BaseAuditableEntity"/> records.
/// </summary>
public class AuditInterceptor(TimeProvider timeProvider) : SaveChangesInterceptor
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

        var updatedEntities = context.ChangeTracker.Entries<BaseAuditableEntity>()
            .Where(HasEntityUpdated);

        foreach (EntityEntry<BaseAuditableEntity> entry in updatedEntities)
        {
            DateTimeOffset utcNow = timeProvider.GetUtcNow();

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedBy = "System"; // TODO: Use UserProvider to get actual user
                entry.Entity.Created = utcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
                entry.Entity.Deleted = true;
            }

            entry.Entity.LastModifiedBy = "System"; // TODO: Use UserProvider to get actual user
            entry.Entity.LastModified = utcNow;
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
