namespace Skylight.Domain.Entities;

public class Tag : BaseAuditableEntity
{
	public required string Name { get; set; }

	public required string Description { get; set; }
}
