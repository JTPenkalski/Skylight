namespace Skylight.Domain.Extensions;

/// <summary>
/// Extension methods for any type of collection.
/// </summary>
public static class EnumerableExtensions
{
	/// <summary>
	/// Converts an Enum array to lowercase.
	/// </summary>
	/// <remarks>
	/// Used when case-sensitivity is required.
	/// </remarks>
	/// <param name="values">The array of enum values to convert.</param>
	/// <returns>A string array of lowercase values.</returns>
	public static string[]? ToLower<T>(this IEnumerable<T>? values) where T : Enum =>
		values?.Select(x => x.ToString().ToLowerInvariant()).ToArray();
}
