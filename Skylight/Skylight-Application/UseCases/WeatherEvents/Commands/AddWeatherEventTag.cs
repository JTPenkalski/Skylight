using FluentResults;
using Microsoft.EntityFrameworkCore;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.Interfaces.Data;
using Skylight.Domain.Entities;
using Skylight.Utilities.Extensions;

namespace Skylight.Application.UseCases.WeatherEvents;

public sealed record AddWeatherEventTagCommand(
	Guid WeatherEventId,
	string TagName)
	: ICommand<AddWeatherEventTagResponse>;

public sealed record AddWeatherEventTagResponse(bool Added)
	: IResponse;

public class AddWeatherEventTagCommandHandler(ISkylightContext dbContext)
	: ICommandHandler<AddWeatherEventTagCommand, AddWeatherEventTagResponse>
{
	public async Task<Result<AddWeatherEventTagResponse>> Handle(AddWeatherEventTagCommand request, CancellationToken cancellationToken)
	{
		WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);
		Tag tag = await dbContext.Tags.FirstOrDefaultAsync(x => EF.Functions.Like(x.Name, request.TagName), cancellationToken)
			?? new Tag
			{
				Name = request.TagName.ToLower().CapitalizeFirst().Trim(),
				Description = "User-submitted Tag."
			};

		var weatherEventTag = new WeatherEventTag
		{
			Event = weatherEvent,
			Tag = tag
		};

		bool added = weatherEvent.AddTag(weatherEventTag);

		await dbContext.CommitAsync(cancellationToken);

		var response = new AddWeatherEventTagResponse(added);

		return Result.Ok(response);
	}
}
