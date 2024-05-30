using FluentValidation;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Models;

/// <summary>
/// Filter used when querying active alerts to specify a location.
/// </summary>
public abstract record AlertLocation()
{
	/// <summary>
	/// The name of the URL query parameter.
	/// </summary>
	public abstract string QueryName { get; }

	/// <summary>
	/// The value of the URL query parameter.
	/// </summary>
	public abstract object? QueryValue { get; }
}

/// <summary>
/// Filter alerts by <see cref="StateTerritoryCode"/> or <see cref="MarineRegionCode"/>.
/// </summary>
/// <remarks>
/// Only one of the two may be used. If both, or none, are specified, an exception will be thrown.
/// </remarks>
public sealed record AreaAlertLocation(StateTerritoryCode[]? StateCodes = null, MarineAreaCode[]? MarineCodes = null) : AlertLocation()
{
	public override string QueryName => "area";

	public override object? QueryValue => StateCodes is not null ? StateCodes : MarineCodes;
}

public class AreaAlertLocationValidator : AbstractValidator<AreaAlertLocation>
{
	public AreaAlertLocationValidator()
	{
		RuleFor(x => x.StateCodes)
			.Empty()
			.When(x => x.MarineCodes is not null);

		RuleFor(x => x.MarineCodes)
			.Empty()
			.When(x => x.StateCodes is not null);
	}
}

/// <summary>
/// Filter alerts by geographic point.
/// </summary>
public sealed record PointAlertLocation(string Latitude, string Longitude) : AlertLocation()
{
	public override string QueryName => "point";

	public override object? QueryValue => $"{Latitude},{Longitude}";
}

/// <summary>
/// Filter alerts by <see cref="MarineRegionCode"/>.
/// </summary>
public sealed record RegionAlertLocation(MarineRegionCode[] Codes) : AlertLocation()
{
	public override string QueryName => "region";

	public override object? QueryValue => Codes;
}

/// <summary>
/// Filter alerts by <see cref="RegionType"/>.
/// </summary>
public sealed record RegionTypeAlertLocation(RegionType Type) : AlertLocation()
{
	public override string QueryName => "region_type";

	public override object? QueryValue => Type.ToString().ToLowerInvariant();
}

/// <summary>
/// Filter alerts by Zone.
/// </summary>
public sealed record ZoneAlertLocation(string[] ZoneIds) : AlertLocation()
{
	public override string QueryName => "zone";

	public override object? QueryValue => ZoneIds;
}

public class ZoneAlertLocationValidator : AbstractValidator<ZoneAlertLocation>
{
	public ZoneAlertLocationValidator()
	{
		RuleForEach(x => x.ZoneIds)
			.Matches(@"^(A[KLMNRSZ]|C[AOT]|D[CE]|F[LM]|G[AMU]|I[ADLN]|K[SY]|L[ACEHMOS]|M[ADEHINOPST]|N[CDEHJMVY]|O[HKR]|P[AHKMRSWZ]|S[CDL]|T[NX]|UT|V[AIT]|W[AIVY]|[HR]I)[CZ]\d{3}$");
	}
}
