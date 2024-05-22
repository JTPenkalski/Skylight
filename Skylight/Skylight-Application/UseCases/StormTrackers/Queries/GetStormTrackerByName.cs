using FluentResults;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.StormTrackers;

public sealed record GetStormTrackerByNameQuery(
    string? FirstName = null,
    string? LastName = null)
    : IQuery<GetStormTrackerByNameResponse>;

public sealed record GetStormTrackerByNameResponse(
    string FirstName,
    string LastName,
    string? Biography = null,
    DateTimeOffset? StartDate = null)
    : IResponse;

public class GetStormTrackerByNameQueryHandler(ISkylightContext context)
    : IQueryHandler<GetStormTrackerByNameQuery, GetStormTrackerByNameResponse>
{
    public async Task<Result<GetStormTrackerByNameResponse>> Handle(GetStormTrackerByNameQuery request, CancellationToken cancellationToken)
    {
        StormTracker? stormTracker = await context.StormTrackers
            .FirstOrDefaultAsync(x => FirstAndLastNameMatch(x, request.FirstName, request.LastName), cancellationToken);

        if (stormTracker is null)
        {
            return Result.Fail($"{nameof(StormTracker)} was not found.");
        }

        var response = new GetStormTrackerByNameResponse(
            FirstName: stormTracker.FirstName,
            LastName: stormTracker.LastName,
            Biography: stormTracker.Biography,
            StartDate: stormTracker.StartDate);

        return Result.Ok(response);
    }

    internal static bool FirstAndLastNameMatch(StormTracker tracker, string? firstName, string? lastName) =>
        (string.IsNullOrWhiteSpace(firstName) || tracker.FirstName == firstName)
        && (string.IsNullOrWhiteSpace(lastName) || tracker.LastName == lastName);
}
