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
    private readonly List<DomainEvent> allEvents = [];
    private readonly List<DomainEvent> newEvents = [];

    public static bool operator ==(BaseEntity left, BaseEntity right) => left.Equals(right);

    public static bool operator !=(BaseEntity left, BaseEntity right) => !(left == right);

    public Guid Id { get; set; }

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> AllEvents => allEvents;

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> NewEvents => newEvents;

    public override bool Equals(object? obj) => Equals(obj as BaseEntity);

    public override int GetHashCode() => Id.GetHashCode();

    public bool Equals(BaseEntity? other) => other is not null && other.Id == Id;

    public void HandleNewEvents()
    {
        newEvents.CopyTo([.. allEvents]);
        newEvents.Clear();
    }

    protected void RaiseEvent(DomainEvent domainEvent)
    {
        newEvents.Add(domainEvent);
        allEvents.Add(domainEvent);
    }
}
