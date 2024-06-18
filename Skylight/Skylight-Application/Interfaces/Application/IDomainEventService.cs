using Skylight.Domain.Entities;
using Skylight.Domain.Events;
using Skylight.Domain.Exceptions;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Handles the dispatching of <see cref="DomainEvent"/>s to the necessary handlers.
/// </summary>
public interface IDomainEventService
{
	/// <summary>
	/// Gets all the generalized <see cref="Event"/> records for <paramref name="entity"/> from its <see cref="BaseEntity.Events"/>.
	/// </summary>
	/// <param name="entity">The <see cref="BaseEntity"/> to save the <see cref="DomainEvent"/>s for.</param>
	/// <returns>A collection of all the <see cref="DomainEvent"/>s for <paramref name="entity"/>, ready to be saved to the database.</returns>
	IEnumerable<Event> GetEvents(BaseEntity entity);

	/// <summary>
	/// Publishes domain events for consumers.
	/// </summary>
	/// <param name="event">The raw event to publish.</param>
	/// <exception cref="InvalidDomainEventException"/>
	Task PublishDomainEventAsync(Event @event, CancellationToken cancellationToken = default);
}
