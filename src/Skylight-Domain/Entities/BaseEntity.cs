using Skylight.Domain.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skylight.Domain.Entities;

/// <summary>
/// Represents the shared properties of all domain entities.
/// </summary>
/// <remarks>
/// Consider using <see cref="BaseAuditableEntity"/> to track auditable data as well.
/// </remarks>
public abstract class BaseEntity : IEquatable<BaseEntity>
{
    private readonly List<DomainEvent> events = [];

    public static bool operator ==(BaseEntity left, BaseEntity right) => left.Equals(right);

    public static bool operator !=(BaseEntity left, BaseEntity right) => !(left == right);

	[DatabaseGenerated(DatabaseGeneratedOption.None)]
	public Guid Id { get; set; } = Guid.NewGuid();

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> Events => events;

    public override int GetHashCode() => Id.GetHashCode();

    public override bool Equals(object? obj) => Equals(obj as BaseEntity);

    public virtual bool Equals(BaseEntity? other) =>
		other is not null
		&& Id != Guid.Empty
		&& other.Id != Guid.Empty
		&& other.Id == Id;

	public void ClearEvents()
	{
		events.Clear();
	}

	protected void AddEvent(DomainEvent domainEvent)
    {
        events.Add(domainEvent);
    }

	protected bool RemoveEvent(DomainEvent domainEvent)
	{
		return events.Remove(domainEvent);
	}
}
