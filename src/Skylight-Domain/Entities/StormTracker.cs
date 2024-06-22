namespace Skylight.Domain.Entities;

/// <summary>
/// A person who tracks severe weather.
/// </summary>
public class StormTracker : BaseAuditableEntity
{
    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public string? Biography { get; set; }

    public DateTimeOffset? StartDate { get; set; }
}
