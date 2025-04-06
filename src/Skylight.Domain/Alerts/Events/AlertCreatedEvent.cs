using Skylight.Domain.Common.Events;

namespace Skylight.Domain.Alerts.Events;

public record AlertCreatedEvent(Guid Id) : DomainEvent;
