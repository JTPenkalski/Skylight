using Mono.Cecil;

namespace Skylight.Tests.Architecture.Utilities;

/// <summary>
/// Utilities for working with the <see cref="Mono.Cecil"/> library.
/// </summary>
internal static class MonoHelpers
{
    /// <summary>
    /// Checks if <paramref name="type"/> is <see cref="Void"/>.
    /// </summary>
    /// <returns>True if void, false otherwise.</returns>
    internal static bool IsVoid(this TypeReference type) =>
        type.FullName.Contains(typeof(void).FullName!);

    /// <summary>
    /// Checks if the name of <paramref name="type"/> contains the name of <typeparamref name="T"/>.
    /// </summary>
    /// <returns>True if the names align, false otherwise.</returns>
    internal static bool HasNameMatchingType<T>(this TypeReference type) =>
        type.FullName.Contains(typeof(T).FullName ?? string.Empty);
}
