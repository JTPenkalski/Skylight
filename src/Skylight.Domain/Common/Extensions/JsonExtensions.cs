﻿using System.Text.Json;

namespace Skylight.Domain.Common.Extensions;

/// <summary>
/// Extension methods for JSON parsing and manipulation.
/// </summary>
public static class JsonExtensions
{
	/// <summary>
	/// Reads a JSON property, returning null if the element has no value.
	/// </summary>
	/// <param name="propertyName">The property to search for.</param>
	/// <returns>The <see cref="JsonElement"/>, or null if not found.</returns>
	public static JsonElement? GetOptionalProperty(this JsonElement element, string propertyName) =>
		element.TryGetProperty(propertyName, out JsonElement value) && value.ValueKind is not JsonValueKind.Undefined and not JsonValueKind.Null
			? value
			: null;
}
