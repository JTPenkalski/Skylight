namespace Skylight.Tests.Infrastructure.Utilities;

/// <summary>
/// Utilities for common asserts for Client types.
/// </summary>
internal static class ClientAsserts
{
    /// <summary>
    /// Asserts that <paramref name="request"/> contains <c>/<paramref name="route"/></c>.
    /// </summary>
    /// <param name="request">The actual request.</param>
    /// <param name="route">The expected route.</param>
    internal static void ContainsRoute(string request, string route) =>
        Assert.Contains($"/{route}", request);

    /// <summary>
    /// Inverts <see cref="ContainsRoute(string, string)"/>.
    /// </summary>
    /// <inheritdoc cref="ContainsRoute(string, string)"/>
    internal static void DoesNotContainRoute(string request, string route) =>
        Assert.DoesNotContain($"/{route}", request);

    /// <summary>
    /// Asserts that <paramref name="request"/> contains <c>?<paramref name="queryName"/>=<paramref name="queryValues"/></c>.
    /// </summary>
    /// <param name="request">The actual request.</param>
    /// <param name="queryName">The expected query name.</param>
    /// <param name="queryValues">The expected query value, or anything if none is provided.</param>
    internal static void ContainsQuery(string request, string queryName, params string[] queryValues) =>
        Assert.Contains($"{queryName}={string.Join("%2C", queryValues)}", request);

    /// <summary>
    /// Inverts <see cref="ContainsQuery(string, string, string)"/>.
    /// </summary>
    /// <inheritdoc cref="ContainsQuery(string, string, string)"/>
    internal static void DoesNotContainQuery(string request, string queryName, params string[] queryValues) =>
        Assert.DoesNotContain($"{queryName}={string.Join("%2C", queryValues)}", request);

	/// <summary>
	/// Ensures none of the <paramref name="queryNames"/> are present in <paramref name="request"/>.
	/// </summary>
	/// <param name="queryNames">The expected query names to search for.</param>
	/// <inheritdoc cref="DoesNotContainQuery(string, string, string)"/>
	internal static void DoesNotContainQueries(string request, params string[] queryNames) =>
		Assert.All(queryNames, x => DoesNotContainQuery(request, x));

	/// <summary>
	/// Asserts that <paramref name="request"/> ends with <c>/<paramref name="route"/></c>,
	/// and contains no query parameters.
	/// </summary>
	/// <inheritdoc cref="ContainsRoute(string, string)"/>
	internal static void EndsWithRoute(string request, string route) =>
        Assert.EndsWith($"/{route}", request);
}
