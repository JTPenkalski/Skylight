using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Infrastructure.Jobs;

public sealed class PublishDomainEventsJob(
	TimeProvider timeProvider,
	ILogger<PublishDomainEventsJob> logger,
	ISkylightContext dbContext,
	IDomainEventService domainEventPublisher)
	: IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		ICollection<Event> domainEvents = await dbContext.Events
			.Where(x => !x.HandledOn.HasValue)
			.ToListAsync(cancellationToken);

		int successfulEventsHandled = 0;
		int totalEvents = domainEvents.Count;

		logger.LogInformation("Discovered {Count} Domain Events to process.", totalEvents);

		foreach (Event domainEvent in domainEvents)
		{
			try
			{
				await domainEventPublisher.PublishDomainEventAsync(domainEvent, cancellationToken);

				successfulEventsHandled++;
				domainEvent.HandledOn = timeProvider.GetUtcNow();

				logger.LogInformation("Successfully processed Domain Event '{Id}'.", domainEvent.Id);
			}
			catch (Exception ex)
			{
				domainEvent.Failures++;

				logger.LogError(ex, "Failed processing Domain Event '{Id}'!", domainEvent.Id);
			}
			finally
			{
				string x = dbContext.ChangeTrackingStatus;

				await Console.Out.WriteLineAsync(x);

				await dbContext.CommitAsync(cancellationToken);
			}
		}

		logger.LogInformation("Finished processing Domain Events. {Successful} / {Total} successfully handled.", successfulEventsHandled, totalEvents);
	}
}
