using MediatR;
using Skylight.Application.Interfaces.Application;
using Skylight.Domain.Entities;
using Skylight.Domain.Events;

namespace Skylight.Application.Messaging;

public class DomainEventPublisher(IMediator mediator) : IDomainEventPublisher
{
    public async Task PublishDomainEventsAsync(IEnumerable<BaseEntity> entities, CancellationToken cancellationToken = default)
    {
        IEnumerable<DomainEvent> domainEvents = entities.SelectMany(x => x.NewEvents);

        foreach (BaseEntity entity in entities)
        {
            foreach (DomainEvent domainEvent in entity.NewEvents)
            {
                await mediator.Publish(domainEvent, cancellationToken);
            }

            entity.HandleNewEvents();
        }
    }
}
