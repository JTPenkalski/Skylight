using Mediator;
using Microsoft.Extensions.Logging;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Behaviors;

/// <summary>
/// Catches uncaught exceptions and returns a failed <see cref="Result"/> to the sender for specific types.
/// </summary>
public class ExceptionBehavior<TMessage, TResponse>(ILogger<ExceptionBehavior<TMessage, TResponse>> logger)
	: IPipelineBehavior<TMessage, TResponse>
	where TMessage : IMessage
	where TResponse : Result, new()
{
	public async ValueTask<TResponse> Handle(TMessage message, CancellationToken cancellationToken, MessageHandlerDelegate<TMessage, TResponse> next)
	{
		try
		{
			return await next(message, cancellationToken);
		}
		catch (Exception ex)
		{
			var result = new TResponse();
			result.AddErrors(new Error(ex));

			logger.LogError(ex, "An unexpected error occurred processing a {RequestType} request. {RequestValue}",
				typeof(TMessage).Name,
				message.ToString());

			return result;
		}
	}
}
