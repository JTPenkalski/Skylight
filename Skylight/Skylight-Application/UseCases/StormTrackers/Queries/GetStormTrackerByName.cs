using FluentResults;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;

namespace Skylight.Application.UseCases.StormTrackers;

public sealed record GetStormTrackersByNameQuery(
    string? FirstName = null,
    string? LastName = null)
    : IQuery<GetStormTrackersByNameResponse>;

public sealed record GetStormTrackersByNameResponse : IResponse
{
    public required IEnumerable<StormTrackerByName> StormTrackers { get; init; } = [];

    public sealed record StormTrackerByName(
        string FirstName,
        string LastName,
        string? Biography = null,
        DateTimeOffset? StartDate = null);
};

public class GetStormTrackersByNameQueryHandler(ISkylightContext context)
    : IQueryHandler<GetStormTrackersByNameQuery, GetStormTrackersByNameResponse>
{
    public async Task<Result<GetStormTrackersByNameResponse>> Handle(GetStormTrackersByNameQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<StormTracker> stormTrackers = await context.StormTrackers
            .Where(x => FirstAndLastNameMatch(x, request.FirstName, request.LastName))
            .ToListAsync(cancellationToken);

        var response = new GetStormTrackersByNameResponse
        {
            StormTrackers = stormTrackers.Select(x => new GetStormTrackersByNameResponse.StormTrackerByName(
                FirstName: x.FirstName,
                LastName: x.LastName,
                Biography: x.Biography,
                StartDate: x.StartDate))
        };

        return Result.Ok(response);
    }

    internal static bool FirstAndLastNameMatch(StormTracker tracker, string? firstName, string? lastName) =>
        (string.IsNullOrWhiteSpace(firstName) || tracker.FirstName == firstName)
        && (string.IsNullOrWhiteSpace(lastName) || tracker.LastName == lastName);
}
