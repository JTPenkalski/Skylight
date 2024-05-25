using Skylight.Infrastructure.Constants;
using System.Text.Json;

namespace Skylight.Infrastructure.Clients;

/// <summary>
/// Base client for all shared client functionality.
/// </summary>
public abstract class BaseClient
{
    protected static IReadOnlyDictionary<string, JsonElement> GetGeoJsonGeometries(JsonElement root) =>
        root.GetProperty(GeoJson.FeaturesKey)
            .EnumerateArray()
            .ToDictionary(
                x => x.GetProperty(GeoJson.IdKey).GetString()!,
                x => x.GetProperty(GeoJson.GeometryKey));

    protected static IReadOnlyDictionary<string, JsonElement> GetGeoJsonProperties(JsonElement root) =>
                root.GetProperty(GeoJson.FeaturesKey)
            .EnumerateArray()
            .ToDictionary(
                x => x.GetProperty(GeoJson.IdKey).GetString()!,
                x => x.GetProperty(GeoJson.PropertiesKey));
}
