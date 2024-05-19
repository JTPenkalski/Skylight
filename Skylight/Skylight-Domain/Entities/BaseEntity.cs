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

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> AllEvents => allEvents;

    [NotMapped]
    public IReadOnlyCollection<DomainEvent> NewEvents => newEvents;

    private readonly List<DomainEvent> allEvents = [];
    private readonly List<DomainEvent> newEvents = [];

    protected void RaiseEvent(DomainEvent domainEvent)
    {
        newEvents.Add(domainEvent);
        allEvents.Add(domainEvent);
    }

    public void HandleNewEvents()
    {
        newEvents.CopyTo([..allEvents]);
        newEvents.Clear();
    }
}
