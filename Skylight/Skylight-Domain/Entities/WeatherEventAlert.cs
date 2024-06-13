using Skylight.Domain.Extensions;

namespace Skylight.Domain.Entities;

/// <summary>
/// Links a type of <see cref="WeatherAlert"/> to a specific <see cref="WeatherEvent"/>.
/// </summary>
public class WeatherEventAlert : BaseAuditableEntity
{
	private readonly List<WeatherAlertModifier> modifiers = [];
	private readonly List<Location> locations = [];

	public required string Sender { get; set; }

	public required string Headline { get; set; }

	public required string Instruction { get; set; }

	public required string Description { get; set; }

    public required DateTimeOffset Sent { get; set; }
    
    public required DateTimeOffset Effective { get; set; }
    
    public required DateTimeOffset Expires { get; set; }
    
    public DateTimeOffset? Onset { get; set; }
    
    public DateTimeOffset? Ends { get; set; }

	public string? ExternalId { get; set; }

    public required virtual WeatherAlert Alert { get; set; }

    public required virtual WeatherEvent Event { get; set; }

	public virtual IReadOnlyList<WeatherAlertModifier> Modifiers => modifiers;

	public virtual IReadOnlyList<Location> Locations => locations;

	public void AddModifier(WeatherAlertModifier modifier)
	{
		modifiers.Add(modifier);
	}

	public bool RemoveModifier(WeatherAlertModifier modifier)
	{
		return modifiers.Remove(modifier);
	}

	public bool RemoveModifierById(Guid modifierId)
	{
		return modifiers.RemoveById(modifierId);
	}

	public void AddLocation(Location location)
	{
		locations.Add(location);
	}

	public bool RemoveLocation(Location location)
	{
		return locations.Remove(location);
	}

	public bool RemoveLocationById(Guid locationId)
	{
		return locations.RemoveById(locationId);
	}
}
