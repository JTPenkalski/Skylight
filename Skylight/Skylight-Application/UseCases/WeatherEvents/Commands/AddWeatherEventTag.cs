using FluentResults;
using FluentValidation;
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

public class AddWeatherEventTagCommandValidator : AbstractValidator<AddWeatherEventTagCommand>
{
	public AddWeatherEventTagCommandValidator()
	{
		RuleFor(x => x.TagName)
			.NotEmpty();
	}
}

public class AddWeatherEventTagCommandHandler(ISkylightContext dbContext)
	: ICommandHandler<AddWeatherEventTagCommand, AddWeatherEventTagResponse>
{
	public async Task<Result<AddWeatherEventTagResponse>> Handle(AddWeatherEventTagCommand request, CancellationToken cancellationToken)
	{
		WeatherEvent weatherEvent = await dbContext.FindAsync<WeatherEvent>(request.WeatherEventId, cancellationToken);

		var weatherEventTag = new WeatherEventTag
		{
			Event = weatherEvent,
			Tag = new Tag
			{
				Name = request.TagName.ToLower().CapitalizeFirst().Trim(),
				Description = "User-submitted Tag."
			}
		};

		bool added = weatherEvent.AddTag(weatherEventTag);

		await dbContext.CommitAsync(cancellationToken);

		var response = new AddWeatherEventTagResponse(added);

		return Result.Ok(response);
	}
}
