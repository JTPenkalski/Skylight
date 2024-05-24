using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Skylight.Application.Interfaces.Application;
using Skylight.Domain.Entities;

namespace Skylight.Data.Interceptors;

/// <summary>
/// Publishes all <see cref="BaseEntity.NewEvents"/> for handlers to respond to.
/// </summary>
public class DomainEventInterceptor(IDomainEventPublisher domainEventPublisher) : SaveChangesInterceptor
{
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        PublishDomainEvents(eventData.Context).AsTask().GetAwaiter().GetResult();

        return base.SavedChanges(eventData, result);
    }

    public override async ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
    {
        await PublishDomainEvents(eventData.Context, cancellationToken);

        return await base.SavedChangesAsync(eventData, result, cancellationToken);
    }

    internal virtual async ValueTask PublishDomainEvents(DbContext? context, CancellationToken cancellationToken = default)
    {
        if (context == null) return;

        await domainEventPublisher.PublishDomainEventsAsync(context.ChangeTracker.Entries<BaseEntity>().Select(x => x.Entity), cancellationToken);
    }
}
