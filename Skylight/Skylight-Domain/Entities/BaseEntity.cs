using Skylight.Domain.Events;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skylight.Domain.Entities;

/// <summary>
/// Represents the shared properties of all domain entities.
/// </summary>
/// <remarks>
/// Consider using <see cref="BaseAuditableEntity"/> to track auditable data as well.
/// </remarks>
public abstract class BaseEntity
{
    public Guid Id { get; set; }

    private readonly List<DomainEvent> domainEvents = [];

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> DomainEvents => domainEvents.AsReadOnly();

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        domainEvents.Add(domainEvent);
    }

    public void RemoveDomainEvent(DomainEvent domainEvent)
    {
        domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        domainEvents.Clear();
    }
}
