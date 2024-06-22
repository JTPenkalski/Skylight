using MediatR;
using System.Text.Json.Serialization;

namespace Skylight.Domain.Events;

[JsonDerivedType(typeof(WeatherEventTagAddedEvent))]
public abstract record DomainEvent : INotification;
