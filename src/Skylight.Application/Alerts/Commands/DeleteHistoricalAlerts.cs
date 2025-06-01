using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Common.Data;
using Skylight.Application.Common.Features;
using Skylight.Application.Common.Results;

namespace Skylight.Application.Alerts.Commands;

public sealed record DeleteHistoricalAlertsCommand(int Hours) : ICommand<DeleteHistoricalAlertsResponse>;

public sealed record DeleteHistoricalAlertsResponse(int AlertCount, int EventCount) : IResponse;

public class DeleteHistoricalAlertsHandler(ISkylightDbContext dbContext, TimeProvider timeProvider) : ICommandHandler<DeleteHistoricalAlertsCommand, DeleteHistoricalAlertsResponse>
{
	public async ValueTask<Result<DeleteHistoricalAlertsResponse>> Handle(DeleteHistoricalAlertsCommand request, CancellationToken cancellationToken)
	{
		DateTimeOffset deleteThreshold = timeProvider.GetUtcNow().AddHours(-request.Hours);

		int deletedAlerts = await dbContext.Alerts
			.Where(x => x.ExpiresOn <= deleteThreshold)
			.ExecuteDeleteAsync(cancellationToken);

		int deletedEvents = await dbContext.Events
			.Where(x => x.HandledOn <= deleteThreshold)
			.ExecuteDeleteAsync(cancellationToken);

		await dbContext.CommitAsync(cancellationToken);

		var response = new DeleteHistoricalAlertsResponse(deletedAlerts, deletedEvents);

		return Result.Success(response);
	}
}
