using Skylight.Domain.Common.Entities;

namespace Skylight.Domain.Common.Events;

/// <summary>
/// A generic representation of a persisted <see cref="DomainEvent"/>.
/// </summary>
public class Event : BaseEntity
{
	public required string Type { get; set; }

	public required string Payload { get; set; }

	public int Failures { get; set; }

	public DateTimeOffset? HandledOn { get; set; }
}
