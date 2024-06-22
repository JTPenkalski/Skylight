namespace Skylight.Domain.Entities;

/// <summary>
/// A generic representation of a persisted <see cref="Events.DomainEvent"/>.
/// </summary>
public class Event : BaseEntity
{
	public DateTimeOffset? HandledOn { get; set; }
	
	public int Failures { get; set; }

	public required string Type { get; set; }

	public required string Payload { get; set; }
}
