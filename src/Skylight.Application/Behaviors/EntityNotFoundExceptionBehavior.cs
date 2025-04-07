using Mediator;
using Skylight.Domain.Common.Exceptions;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Behaviors;

/// <summary>
/// Catches any <see cref="EntityNotFoundException"/> and returns a failed <see cref="Result"/> to the sender.
/// </summary>
public class EntityNotFoundExceptionBehavior<TMessage, TResponse> : IPipelineBehavior<TMessage, TResponse>
	where TMessage : IMessage
	where TResponse : Result, new()
{
	public async ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next)
	{
		try
		{
			return await next(message, cancellationToken);
		}
		catch (EntityNotFoundException ex)
		{
			var result = new TResponse();
			result.Errors.Add(new Error(ex.Message));

			return result;
		}
	}
}
