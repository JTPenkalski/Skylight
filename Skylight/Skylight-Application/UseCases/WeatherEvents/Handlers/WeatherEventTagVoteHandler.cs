using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;
using Skylight.Domain.Events;
using Skylight.Domain.Exceptions;

namespace Skylight.Application.UseCases.WeatherEvents.Handlers;

public class WeatherEventTagVoteHandler(ISkylightContext dbContext) : IDomainEventHandler<WeatherEventTagAddedEvent>
{
	public async Task Handle(WeatherEventTagAddedEvent notification, CancellationToken cancellationToken)
	{
		WeatherEventTag? weatherEventTag = (await dbContext.FindAsync<WeatherEvent>(notification.WeatherEventId, cancellationToken)).Tags
			.SingleOrDefault(x => x.Id == notification.WeatherEventTagId);

		EntityNotFoundException.ThrowIfNullOrDeleted(weatherEventTag, notification.WeatherEventTagId);

		weatherEventTag.Votes++;

		await dbContext.CommitAsync(cancellationToken);
	}
}
