using MediatR;
using Skylight.Application.Interfaces.Application;
using Skylight.Domain.Entities;
using Skylight.Domain.Events;
using Skylight.Domain.Exceptions;
using System.Text.Json;

namespace Skylight.Application.Events;

public class DomainEventService(IMediator mediator) : IDomainEventService
{
	private static readonly JsonSerializerOptions domainEventSerializerOptions = new()
	{
		TypeInfoResolver = new DomainEventJsonTypeResolver(),
	};

	public IEnumerable<Event> GetEvents(BaseEntity entity) =>
		entity.Events
			.Select(x => new Event
			{
				Type = x.GetType().Name,
				Payload = JsonSerializer.Serialize(x, domainEventSerializerOptions)
			});

	public async Task PublishDomainEventAsync(Event @event, CancellationToken cancellationToken = default)
	{
		DomainEvent? domainEvent = JsonSerializer.Deserialize<DomainEvent?>(@event.Payload, domainEventSerializerOptions);

		InvalidDomainEventException.ThrowIfNull(domainEvent, @event.Type);

		await mediator.Publish(domainEvent, cancellationToken);
	}
}
