using Skylight.Domain.Entities;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Notifies all necessary consumers of <see cref="Domain.Events.DomainEvent"/>s being saved.
/// </summary>
public interface IDomainEventPublisher
{
    /// <summary>
    /// Publishes domain events for consumers.
    /// </summary>
    /// <param name="entities">The modified entities with new events.</param>
    Task PublishDomainEventsAsync(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken = default);
}
