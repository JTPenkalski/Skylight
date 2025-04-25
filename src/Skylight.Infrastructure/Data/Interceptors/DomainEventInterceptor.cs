using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Skylight.Application.Events;
using Skylight.Domain.Common.Entities;

namespace Skylight.Infrastructure.Data.Interceptors;

/// <summary>
/// Saves all <see cref="BaseEntity.Events"/> to the database for future handling.
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

		IEnumerable<BaseEntity> entities = context.ChangeTracker.Entries<BaseEntity>()
			.Select(x => x.Entity);

		await domainEventService.SaveDomainEventsAsync(entities, context, cancellationToken);
	}
}
