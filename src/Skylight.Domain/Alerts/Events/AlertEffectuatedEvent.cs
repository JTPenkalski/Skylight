using Skylight.Domain.Common.Events;

namespace Skylight.Domain.Alerts.Events;

public record AlertEffectuatedEvent(Guid Id) : DomainEvent;
