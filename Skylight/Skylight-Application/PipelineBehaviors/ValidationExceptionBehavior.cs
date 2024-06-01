using FluentResults;
using FluentValidation;
using MediatR;

namespace Skylight.Application.PipelineBehaviors;

/// <summary>
/// Catches any <see cref="ValidationException"/> and returns a failed <see cref="Result"/> to the sender.
/// </summary>
public class ValidationExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
	where TRequest : IBaseRequest
	where TResponse : ResultBase, new()
{
	public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
	{
		try
		{
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
