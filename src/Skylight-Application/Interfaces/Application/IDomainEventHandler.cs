using MediatR;
using Skylight.Domain.Events;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TEvent"/> event.
/// </summary>
public interface IDomainEventHandler<TEvent> : INotificationHandler<TEvent>
	where TEvent : DomainEvent { }
