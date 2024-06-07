namespace Skylight.Domain.Extensions;

/// <summary>
/// Extension methods for types.
/// </summary>
public static class TypeExtensions
{
	/// <summary>
	/// Determines whether this type implements a <paramref name="generic"/> interface.
	/// </summary>
	/// <param name="generic">The type to check assignment against.</param>
	/// <returns>True if this type implements the <paramref name="generic"/> interface, false otherwise.</returns>
	public static bool IsAssignableToGeneric(this Type type, Type generic) =>
		type.GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == generic);
}
