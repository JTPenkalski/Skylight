using Skylight.Application.Serialization;
using System.Text.Json;

namespace Skylight.Infrastructure.Serialization;

public class GeoJsonService : IGeoJsonService
{
	public IReadOnlyDictionary<string, JsonElement> GetGeoJsonGeometries(JsonElement root) =>
		root.GetProperty(GeoJson.FeaturesKey)
			.EnumerateArray()
			.DistinctBy(x => x.GetProperty(GeoJson.IdKey).GetString()!)
			.ToDictionary(
				x => x.GetProperty(GeoJson.IdKey).GetString()!,
				x => x.GetProperty(GeoJson.GeometryKey));

	public IReadOnlyDictionary<string, JsonElement> GetGeoJsonProperties(JsonElement root) =>
		root.GetProperty(GeoJson.FeaturesKey)
			.EnumerateArray()
			.DistinctBy(x => x.GetProperty(GeoJson.IdKey).GetString()!)
			.ToDictionary(
				x => x.GetProperty(GeoJson.IdKey).GetString()!,
				x => x.GetProperty(GeoJson.PropertiesKey));
}
