using FluentValidation;
using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace Skylight.Infrastructure.Clients;

/// <summary>
/// Base client for all shared client functionality.
/// </summary>
public abstract class BaseClient(ILogger logger)
{
	internal abstract IFlurlRequest BaseRequest { get; }

	/// <summary>
	/// Prepares and executes web request, returning a marshalled response.
	/// </summary>
	/// <param name="request">The web request to execute.</param>
	/// <param name="responsePreparer">The mapping between the response and <typeparamref name="TResponse"/>.</param>
	/// <returns>The response object.</returns>
	protected async Task<TResponse> ExecuteRequestAsync<TRequest, TResponse>(
		TRequest request,
		Func<TRequest, IFlurlRequest> requestPreparer,
		Func<string, TResponse> responsePreparer,
		CancellationToken cancellationToken,
		IValidator<TRequest>? validator = null)
		where TRequest : IClientRequest
		where TResponse : IClientResponse
	{
		if (validator is not null)
		{
			await validator.ValidateAndThrowAsync(request, cancellationToken);
		}

		IFlurlRequest clientRequest = requestPreparer(request);

		logger.LogInformation("Executing HTTP request to {Url}.", clientRequest.Url);

		string clientResponse = await clientRequest.GetStringAsync(cancellationToken: cancellationToken);
		TResponse response = responsePreparer(clientResponse);

		return response;
	}
}
