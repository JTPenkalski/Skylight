using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Common.Data;
using Skylight.Application.Common.Features;
using Skylight.Application.Common.Results;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Application.Alerts.Commands;

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
