using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.GetAlertSenders;

public class GetAlertSendersHandler(ISkylightDbContext dbContext) : IQueryHandler<GetAlertSendersQuery, GetAlertSendersResponse>
{
	public async ValueTask<Result<GetAlertSendersResponse>> Handle(GetAlertSendersQuery request, CancellationToken cancellationToken)
	{
		var types = await dbContext.AlertSenders
			.OrderBy(x => x.Code)
			.Select(x => new GetAlertSendersResponse.AlertSender(
				x.Code,
				x.Name))
			.ToListAsync(cancellationToken);

		var response = new GetAlertSendersResponse(types);

		return Result.Success(response);
	}
}
