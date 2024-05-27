using Skylight.Infrastructure.Constants;
using System.Text.Json;

namespace Skylight.Infrastructure.Clients;

/// <summary>
/// Base client for all shared client functionality.
/// </summary>
public abstract class BaseClient
{
	/// <summary>
	/// Converts an Enum array to lowercase.
	/// </summary>
	/// <remarks>
	/// Used when the API is case-sensitive and requires lowercase values.
	/// </remarks>
	/// <param name="values">The array of enum values to convert.</param>
	/// <returns>A string array of lowercase values.</returns>
	protected static string[] ToLower<T>(T[]? values) where T : Enum =>
		values?.Select(x => x.ToString().ToLowerInvariant()).ToArray() ?? [];

	/// <summary>
	/// Parses GeoJson geometry fields, grouped by ID, assuming a standardized format.
	/// </summary>
	/// <param name="root">The root JSON object.</param>
	/// <returns>The GeoJson geometry root.</returns>
    protected static IReadOnlyDictionary<string, JsonElement> GetGeoJsonGeometries(JsonElement root) =>
        root.GetProperty(GeoJson.FeaturesKey)
            .EnumerateArray()
            .ToDictionary(
                x => x.GetProperty(GeoJson.IdKey).GetString()!,
                x => x.GetProperty(GeoJson.GeometryKey));

	/// <summary>
	/// Parses GeoJson property fields, grouped by ID, assuming a standardized format.
	/// </summary>
	/// <param name="root">The root JSON object.</param>
	/// <returns>The GeoJson properties root.</returns>
	protected static IReadOnlyDictionary<string, JsonElement> GetGeoJsonProperties(JsonElement root) =>
                root.GetProperty(GeoJson.FeaturesKey)
            .EnumerateArray()
            .ToDictionary(
                x => x.GetProperty(GeoJson.IdKey).GetString()!,
                x => x.GetProperty(GeoJson.PropertiesKey));
}
