namespace Skylight.Domain.Entities;

public class WeatherEventTag : BaseAuditableEntity
{
	private const int ActivationThreshold = 3;
	
	private int _votes;

	public required virtual WeatherEvent Event { get; set; }

	public required virtual Tag Tag { get; set; }

	public int Votes
	{
		get => _votes;
		set
		{
			value = int.Max(value, 0);
			_votes = value;

			if (value >= ActivationThreshold)
			{
				EffectiveDate = DateTime.UtcNow;
			}
		}
	}

	public DateTimeOffset? EffectiveDate { get; set; }
}
