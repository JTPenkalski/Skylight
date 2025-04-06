using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace Skylight.Infrastructure.Clients;

/// <summary>
/// Base client for all shared client functionality.
/// </summary>
public abstract class BaseClient(ILogger logger)
{
	/// <summary>
	/// Comma-delimits array values for the APIs that require it.
	/// </summary>
	/// <param name="array">The array of values.</param>
	/// <returns>A CSV of the array values, or null if there are no values.</returns>
	protected static string? EncodeArray<T>(T[]? array) =>
		array is not null
			? string.Join(',', array)
			: null;

	/// <summary>
	/// Builds a web request.
	/// </summary>
	/// <param name="request">The <see cref="IClientRequest"/>.</param>
	/// <param name="requestPreparer">The mapping between <typeparamref name="TRequest"/> and the web request.</param>
	/// <returns>A web request ready to be called.</returns>
	protected IFlurlRequest PrepareRequest<TRequest>(TRequest request, Func<TRequest, IFlurlRequest> requestPreparer)
		where TRequest : IClientRequest
	{
		logger.LogInformation("Preparing HTTP request '{Request}'.", typeof(TRequest).Name);

		return requestPreparer(request);
	}

	/// <summary>
	/// Executes a web request.
	/// </summary>
	/// <param name="request">The web request to execute.</param>
	/// <param name="responsePreparer">The mapping between the response and <typeparamref name="TResponse"/>.</param>
	/// <returns>The response object.</returns>
	protected async Task<TResponse> ExecuteRequestAsync<TResponse>(IFlurlRequest request, Func<string, TResponse> responsePreparer, CancellationToken cancellationToken)
	{
		logger.LogInformation("Executing HTTP request to {Url}.", request.Url);

		string response = await request.GetStringAsync(cancellationToken: cancellationToken);

		return responsePreparer(response);
	}
}
