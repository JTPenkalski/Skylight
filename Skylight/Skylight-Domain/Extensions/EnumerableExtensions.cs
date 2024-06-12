using Skylight.Domain.Entities;

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

	/// <summary>
	/// Checks if the <see cref="IEnumerable{T}"/> contains <paramref name="item"/>,
	/// but only if it has been saved and has a valid <see cref="BaseEntity.Id"/>.
	/// </summary>
	/// <param name="item">The item to search for.</param>
	/// <returns>True if the item has a default <see cref="BaseEntity.Id"/> or is contained in the collection, false otherwise.</returns>
	public static bool ContainsNonDefault<T>(this IEnumerable<T> values, T item) where T : BaseEntity =>
		item.Id != Guid.Empty || values.Contains(item);

	/// <summary>
	/// Removes an element from the <see cref="List{T}"/> with the specified <paramref name="id"/>.
	/// </summary>
	/// <param name="id">The ID of the element to remove.</param>
	/// <returns>True if the element was successfully removed, false otherwise.</returns>
	public static bool RemoveById<T>(this List<T> list, Guid id) where T : BaseEntity
	{
		T? element = list.Find(x => x.Id == id);

		if (element is not null)
		{
			return list.Remove(element);
		}

		return false;
	}
}
