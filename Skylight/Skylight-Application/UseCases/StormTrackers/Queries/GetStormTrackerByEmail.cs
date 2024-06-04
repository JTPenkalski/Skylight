using FluentResults;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Domain.Entities;
using Skylight.Domain.Exceptions;

namespace Skylight.Application.UseCases.StormTrackers;

public sealed record GetStormTrackerByEmailQuery(string Email) : IQuery<GetStormTrackerByEmailResponse>;

public sealed record GetStormTrackerByEmailResponse(
	Guid StormTrackerId,
	string FirstName,
	string LastName)
	: IResponse;

public class GetStormTrackerByEmailQueryHandler(IUserService userService)
	: IQueryHandler<GetStormTrackerByEmailQuery, GetStormTrackerByEmailResponse>
{
	public async Task<Result<GetStormTrackerByEmailResponse>> Handle(GetStormTrackerByEmailQuery request, CancellationToken cancellationToken)
	{
		StormTracker? stormTracker = await userService.GetStormTrackerByEmail(request.Email, cancellationToken);

		EntityNotFoundException.ThrowIfNullOrDeleted(stormTracker);

		var response = new GetStormTrackerByEmailResponse(
			stormTracker.Id,
			stormTracker.FirstName,
			stormTracker.LastName);

		return Result.Ok(response);
	}
}
