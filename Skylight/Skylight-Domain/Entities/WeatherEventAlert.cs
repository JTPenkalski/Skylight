namespace Skylight.Domain.Entities;

/// <summary>
/// Links a type of <see cref="WeatherAlert"/> to a specific <see cref="WeatherEvent"/>.
/// </summary>
public class WeatherEventAlert : BaseAuditableEntity
{
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

    public virtual IList<WeatherAlertModifier> Modifiers { get; set; } = new List<WeatherAlertModifier>();

	public virtual IList<Location> Locations { get; set; } = new List<Location>();
}
