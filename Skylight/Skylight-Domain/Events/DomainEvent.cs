using MediatR;

namespace Skylight.Domain.Events;

public abstract record DomainEvent(Guid Id) : INotification;
