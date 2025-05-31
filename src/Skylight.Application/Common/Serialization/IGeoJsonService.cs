using System.Text.Json;

namespace Skylight.Application.Common.Serialization;

/// <summary>
/// Reads and writes structured GeoJSON data.
/// </summary>
public interface IGeoJsonService
{
	/// <summary>
	/// Parses GeoJSON geometry fields, grouped by ID, assuming a standardized format.
	/// </summary>
	/// <param name="root">The root JSON object.</param>
	/// <returns>The GeoJSON gometries.</returns>
	IReadOnlyDictionary<string, JsonElement> GetGeoJsonGeometries(JsonElement root);

	/// <summary>
	/// Parses GeoJSON property fields, grouped by ID, assuming a standardized format.
	/// </summary>
	/// <param name="root">The root JSON object.</param>
	/// <returns>The GeoJSON properties.</returns>
	IReadOnlyDictionary<string, JsonElement> GetGeoJsonProperties(JsonElement root);
}
