namespace Skylight.Domain.Common.Extensions;

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
		values?
			.Select(x => x.ToString().ToLowerInvariant())
			.ToArray();

	/// <summary>
	/// Converts an Enum array to uppercase.
	/// </summary>
	/// <remarks>
	/// Used when case-sensitivity is required.
	/// </remarks>
	/// <param name="values">The array of enum values to convert.</param>
	/// <returns>A string array of uppercase values.</returns>
	public static string[]? ToUpper<T>(this IEnumerable<T>? values) where T : Enum =>
		values?
			.Select(x => x.ToString().ToUpperInvariant())
			.ToArray();

	/// <summary>
	/// Comma-delimits a collection of values, if provided.
	/// </summary>
	/// <param name="values">The collection of values.</param>
	/// <returns>A CSV of the values, or null if there are no values.</returns>
	public static string? ToCsv<T>(this IEnumerable<T>? values) =>
		values is not null
			? string.Join(',', values)
			: null;
}
