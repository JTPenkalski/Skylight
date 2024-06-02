using FluentResults;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Skylight.Application.PipelineBehaviors;

/// <summary>
/// Catches any <see cref="ValidationException"/> and returns a failed <see cref="Result"/> to the sender.
/// </summary>
public class ValidationExceptionBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IBaseRequest
	where TResponse : ResultBase, new()
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		try
		{
			IEnumerable<Task<ValidationResult>> validationTasks = validators.Select(x => x.ValidateAsync(request, cancellationToken));
			IEnumerable<ValidationResult> validationResults = await Task.WhenAll(validationTasks);

			if (validationResults.Any())
			{
				IEnumerable<Error> validationErrors = validationResults
					.Where(x => x.Errors.Count > 0)
					.SelectMany(x => x.Errors)
					.Select(x => new Error(x.ErrorMessage));

				var result = new TResponse();
				result.Reasons.AddRange(validationErrors);

				return result;
			}

			return await next();
		}
		catch (ValidationException ex)
		{
			var result = new TResponse();
			result.Reasons.Add(new Error(ex.Message));

			return result;
		}
	}
}
