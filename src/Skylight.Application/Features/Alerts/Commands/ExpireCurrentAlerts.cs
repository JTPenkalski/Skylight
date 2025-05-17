using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.Commands;

public sealed record ExpireCurrentAlertsCommand : ICommand<ExpireCurrentAlertsResponse>;

public sealed record ExpireCurrentAlertsResponse(int Count) : IResponse;

public class ExpireCurrentAlertsHandler(ISkylightDbContext dbContext, TimeProvider timeProvider) : ICommandHandler<ExpireCurrentAlertsCommand, ExpireCurrentAlertsResponse>
{
	public async ValueTask<Result<ExpireCurrentAlertsResponse>> Handle(ExpireCurrentAlertsCommand request, CancellationToken cancellationToken)
	{
		var alerts = await dbContext.Alerts
			.Where(x =>
				!x.IsExpired
				&& x.ExpiresOn <= timeProvider.GetUtcNow()
				&& !x.DeletedOn.HasValue)
			.ToListAsync(cancellationToken);

		foreach (Alert alert in alerts)
		{
			alert.Expire();
		}

		await dbContext.CommitAsync(cancellationToken);

		var response = new ExpireCurrentAlertsResponse(alerts.Count);

		return Result.Success(response);
	}
}
