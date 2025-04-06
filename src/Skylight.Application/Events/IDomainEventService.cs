using Microsoft.EntityFrameworkCore;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Events;
using Skylight.Domain.Common.Exceptions;

namespace Skylight.Application.Events;

/// <summary>
/// Handles the dispatching of <see cref="DomainEvent"/>s to the necessary handlers.
/// </summary>
public interface IDomainEventService
{
	/// <summary>
	/// Persists domain events for future consumption.
	/// </summary>
	/// <param name="entities">The entities with events to save.</param>
	/// <param name="dbContext">The database to save the events to.</param>
	Task SaveDomainEventsAsync(IEnumerable<BaseEntity> entities, DbContext dbContext, CancellationToken cancellationToken);

	/// <summary>
	/// Publishes domain events for consumers.
	/// </summary>
	/// <param name="event">The raw event to publish.</param>
	/// <exception cref="InvalidDomainEventException"/>
	Task PublishDomainEventAsync(Event @event, CancellationToken cancellationToken);
}
