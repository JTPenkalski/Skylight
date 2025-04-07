using Microsoft.EntityFrameworkCore;
using Skylight.Application.Data;
using Skylight.Application.Features.Interfaces;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Alerts.GetAlertTypes;

public class GetAlertTypesHandler(ISkylightDbContext dbContext) : IQueryHandler<GetAlertTypesQuery, GetAlertTypesResponse>
{
	public async ValueTask<Result<GetAlertTypesResponse>> Handle(GetAlertTypesQuery request, CancellationToken cancellationToken)
	{
		var types = await dbContext.AlertTypes
			.Select(x => new GetAlertTypesResponse.AlertType(
				x.Code,
				x.Name,
				x.Description,
				x.Level.ToString()))
			.ToListAsync(cancellationToken);

		var response = new GetAlertTypesResponse(types);

		return Result.Success(response);
	}
}
