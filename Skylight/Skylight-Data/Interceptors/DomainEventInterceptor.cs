using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Skylight.Application.Interfaces.Application;
using Skylight.Domain.Entities;

namespace Skylight.Data.Interceptors;

/// <summary>
/// Saves all <see cref="BaseEntity.NewEvents"/> to the database for future handling.
/// </summary>
public class DomainEventInterceptor(IDomainEventService domainEventService) : SaveChangesInterceptor
{
	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		SaveDomainEventsAsync(eventData.Context).AsTask().GetAwaiter().GetResult();

		return base.SavingChanges(eventData, result);
	}

	public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		await SaveDomainEventsAsync(eventData.Context, cancellationToken);

		return await base.SavingChangesAsync(eventData, result, cancellationToken);
	}

    internal virtual async ValueTask SaveDomainEventsAsync(DbContext? context, CancellationToken cancellationToken = default)
    {
        if (context == null) return;

		IEnumerable<Event> events = context.ChangeTracker
			.Entries<BaseEntity>()
			.SelectMany(x => domainEventService.GetEvents(x.Entity));

		await context.Set<Event>().AddRangeAsync(events, cancellationToken);
	}
}
