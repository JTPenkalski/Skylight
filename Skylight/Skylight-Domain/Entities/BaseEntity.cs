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

    public Guid Id { get; set; }

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> Events => events;

    public override bool Equals(object? obj) => Equals(obj as BaseEntity);

    public override int GetHashCode() => Id.GetHashCode();

    public virtual bool Equals(BaseEntity? other) => other is not null && other.Id == Id;

    protected void RaiseEvent(DomainEvent domainEvent)
    {
        events.Add(domainEvent);
    }

	protected void CancelEvent(DomainEvent domainEvent)
	{
		events.Remove(domainEvent);
	}

	protected void ClearEvents()
	{
		events.Clear();
	}
}
