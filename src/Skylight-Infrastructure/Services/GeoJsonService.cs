using Skylight.Application.Interfaces.Infrastructure;
using Skylight.Infrastructure.Constants;
using System.Text.Json;

namespace Skylight.Infrastructure.Services;

public class GeoJsonService : IGeoJsonService
{
	public IReadOnlyDictionary<string, JsonElement> GetGeoJsonGeometries(JsonElement root) =>
		root.GetProperty(GeoJson.FeaturesKey)
			.EnumerateArray()
			.ToDictionary(
				x => x.GetProperty(GeoJson.IdKey).GetString()!,
				x => x.GetProperty(GeoJson.GeometryKey));

	public IReadOnlyDictionary<string, JsonElement> GetGeoJsonProperties(JsonElement root) =>
		root.GetProperty(GeoJson.FeaturesKey)
			.EnumerateArray()
			.ToDictionary(
				x => x.GetProperty(GeoJson.IdKey).GetString()!,
				x => x.GetProperty(GeoJson.PropertiesKey));
}
