﻿using Mediator;
using Skylight.Domain.Common.Events;

namespace Skylight.Application.Common.Events;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TEvent"/> event.
/// </summary>
public interface IDomainEventHandler<in TEvent>
	: INotificationHandler<TEvent>
	where TEvent : DomainEvent;
