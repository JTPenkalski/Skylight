using Mediator;
using Microsoft.EntityFrameworkCore;
using Skylight.Domain.Common.Entities;
using Skylight.Domain.Common.Events;
using Skylight.Domain.Common.Exceptions;
using System.Text.Json;

namespace Skylight.Application.Common.Events;

public class DomainEventService(IMediator mediator) : IDomainEventService
{
	private static readonly JsonSerializerOptions DomainEventSerializerOptions = new()
	{
		TypeInfoResolver = new DomainEventJsonTypeResolver(),
	};

	public async Task SaveDomainEventsAsync(IEnumerable<BaseEntity> entities, DbContext dbContext, CancellationToken cancellationToken)
	{
		List<Event> events =
		[
			.. entities
			.SelectMany(x => x.Events)
			.Select(x => new Event
			{
				Type = x.GetType().Name,
				Payload = JsonSerializer.Serialize(x, DomainEventSerializerOptions)
			})
		];

		await dbContext.Set<Event>().AddRangeAsync(events, cancellationToken);
	}

	public async Task PublishDomainEventAsync(Event @event, CancellationToken cancellationToken)
	{
		DomainEvent? domainEvent = JsonSerializer.Deserialize<DomainEvent?>(@event.Payload, DomainEventSerializerOptions);

		InvalidDomainEventException.ThrowIfNull(domainEvent, @event.Type);

		await mediator.Publish(domainEvent, cancellationToken);
	}
}
