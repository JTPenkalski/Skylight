namespace Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;

/// <summary>
/// Filter used when querying active alerts to specify a location.
/// </summary>
public abstract record AlertLocation();

/// <summary>
/// Filter alerts by <see cref="StateTerritoryCode"/> or <see cref="MarineRegionCode"/>.
/// </summary>
/// <remarks>
/// Only one of the two may be used. If both, or none, are specified, an exception will be thrown.
/// </remarks>
public sealed record AreaAlertLocation(StateTerritoryCode? StateCode = null, MarineRegionCode? MarineCode = null) : AlertLocation();

/// <summary>
/// Filter alerts by geographic point.
/// </summary>
public sealed record PointAlertLocation(string Latitude, string Longitude) : AlertLocation();

/// <summary>
/// Filter alerts by <see cref="MarineRegionCode"/>.
/// </summary>
public sealed record RegionAlertLocation(MarineRegionCode Code) : AlertLocation();

/// <summary>
/// Filter alerts by <see cref="RegionType"/>.
/// </summary>
public sealed record RegionTypeAlertLocation(RegionType Type) : AlertLocation();

/// <summary>
/// Filter alerts by Zone.
/// </summary>
/// <remarks>
/// <paramref name="ZoneId"/> must match the pattern: ^(A[KLMNRSZ]|C[AOT]|D[CE]|F[LM]|G[AMU]|I[ADLN]|K[SY]|L[ACEHMOS]|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[AHKMRSWZ]|S[CDL]|T[NX]|UT|V[AIT]|W[AIVY]|[HR]I)[CZ]\d{3}$
/// </remarks>
public sealed record ZoneAlertLocation(string ZoneId) : AlertLocation();

