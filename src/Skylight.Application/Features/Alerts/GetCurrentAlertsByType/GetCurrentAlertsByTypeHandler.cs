using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Alerts.Entities;
using Skylight.Domain.Common.Exceptions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.GetCurrentAlertsByType;

public class GetCurrentAlertsByTypeHandler(ISkylightDbContext dbContext) : IQueryHandler<GetCurrentAlertsByTypeQuery, GetCurrentAlertsByTypeResponse>
{
	public async ValueTask<Result<GetCurrentAlertsByTypeResponse>> Handle(GetCurrentAlertsByTypeQuery request, CancellationToken cancellationToken)
	{
		AlertType? alertType = await dbContext.AlertTypes
			.AsNoTracking()
			.SingleOrDefaultAsync(x => x.Code == request.Code, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(alertType, request.Code);

		var alerts = await dbContext.Alerts
			.AsNoTracking()
			.Where(x =>
				x.Type.Code == request.Code
				&& x.ExpiresOn > DateTimeOffset.UtcNow
				&& !x.DeletedOn.HasValue)
			.Select(x => new GetCurrentAlertsByTypeResponse.CurrentAlertByType(
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

		var response = new GetCurrentAlertsByTypeResponse(
			alerts.Count,
			alertType.Code,
			alertType.Name,
			alertType.Level,
			alerts);

		return Result.Success(response);
	}
}
