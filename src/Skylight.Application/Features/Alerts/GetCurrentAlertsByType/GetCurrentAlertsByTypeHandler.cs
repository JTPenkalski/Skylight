using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.GetCurrentAlertsByType;

public class GetCurrentAlertsByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertsByTypeQuery, GetCurrentAlertsByTypeResponse>
{
	public async ValueTask<Result<GetCurrentAlertsByTypeResponse>> Handle(GetCurrentAlertsByTypeQuery request, CancellationToken cancellationToken)
	{
		var alerts = await dbContext.Alerts
			.Where(x =>
				x.Type.Code == request.Code
				&& x.ExpiresOn > DateTimeOffset.UtcNow)
			.Select(x => new GetCurrentAlertsByTypeResponse.CurrentAlertByType(
				x.Type.Code,
				x.Type.Name,
				x.Type.Level,
				x.Sender.Code,
				x.Sender.Name,
				x.Headline,
				x.Description,
				x.Instruction,
				x.SentOn,
				x.EffectiveOn,
				x.ExpiresOn,
				x.MessageType,
				x.Severity,
				x.Certainty,
				x.Urgency,
				x.Response,
				x.Zones.Select(x => x.Code)))
			.ToListAsync(cancellationToken);

		var response = new GetCurrentAlertsByTypeResponse(alerts);

		return Result.Success(response);
	}
}
