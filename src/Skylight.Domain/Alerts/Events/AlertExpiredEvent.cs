using Skylight.Domain.Common.Events;

namespace Skylight.Domain.Alerts.Events;

public record AlertExpiredEvent(Guid Id) : DomainEvent;
