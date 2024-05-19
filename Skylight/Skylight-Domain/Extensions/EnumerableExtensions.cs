namespace Skylight.Domain.Extensions;

/// <summary>
/// Extension methods for any type of collection.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Checks if the provided <paramref name="target"/> is contained within set of potential <paramref name="values"/>.
    /// </summary>
    /// <param name="target">The current value to search for.</param>
    /// <param name="values">The collection of potential values.</param>
    /// <returns>True if the <paramref name="target"/> is found, false otherwise.</returns>
    public static bool OneOf<T>(this T target, params T[] values) => values.Any(x => values.Contains(target));

    /// <inheritdoc cref="OneOf{T}(T, T[])"/>
    public static bool OneOf<T>(this T target, IEnumerable<T> values) => target.OneOf(values.ToArray());

    /// <summary>
    /// Adds additional enumerables to a base collection.
    /// Basically, multiple calls to an <c>AddRange()</c> method that can be chained off a collection initializer.
    /// </summary>
    /// <param name="collection">The base collection to add values to.</param>
    /// <param name="values">Additional enumerables, which will have all their elements added to <paramref name="collection"/>.</param>
    /// <returns>The <paramref name="collection"/> with all values added to it.</returns>
    public static IEnumerable<T> WithRanges<T>(this ICollection<T> collection, params IEnumerable<T>[] values)
    {
        values.SelectMany(values => values).ToList().ForEach(collection.Add);
        return collection;
    }
}
