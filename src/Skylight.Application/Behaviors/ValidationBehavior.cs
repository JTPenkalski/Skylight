using FluentValidation;
using FluentValidation.Results;
using Mediator;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Behaviors;

/// <summary>
/// Validates application requests and returns a failed <see cref="Result"/> to the sender if it fails.
/// </summary>
public class ValidationBehaviour<TMessage, TResponse>(IEnumerable<IValidator<TMessage>> validators) : IPipelineBehavior<TMessage, TResponse>
	where TMessage : IMessage
	where TResponse : Result, new()
{
	public async ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next)
	{
		try
		{
			IEnumerable<Task<ValidationResult>> validationTasks = validators.Select(x => x.ValidateAsync(message, cancellationToken));
			IEnumerable<ValidationResult> validationResults = (await Task.WhenAll(validationTasks)).Where(x => !x.IsValid);

			if (validationResults.Any())
			{
				IEnumerable<Error> validationErrors = validationResults
					.SelectMany(x => x.Errors)
					.Select(x => new Error(x.ErrorMessage));

				var result = new TResponse();
				result.AddErrors(validationErrors);

				return result;
			}

			return await next(message, cancellationToken);
		}
		catch (ValidationException ex)
		{
			var result = new TResponse();
			result.AddErrors(new Error(ex));

			return result;
		}
	}
}
