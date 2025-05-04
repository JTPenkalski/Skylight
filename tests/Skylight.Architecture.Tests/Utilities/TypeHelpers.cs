using Mono.Cecil;

namespace Skylight.Architecture.Tests.Utilities;

/// <summary>
/// Utilities for working with the <see cref="Mono.Cecil"/> library.
/// </summary>
internal static class TypeHelpers
{
	/// <summary>
	/// Determines whether this type implements a <paramref name="generic"/> interface.
	/// </summary>
	/// <param name="generic">The type to check assignment against.</param>
	/// <returns>True if this type implements the <paramref name="generic"/> interface, false otherwise.</returns>
	public static bool IsAssignableToGeneric(this Type type, Type generic) =>
		type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == generic);

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
