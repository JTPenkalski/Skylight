using Skylight.Domain.Common.Events;

namespace Skylight.Domain.Alerts.Events;

public record AlertUpdatedEvent(Guid Id) : DomainEvent;
