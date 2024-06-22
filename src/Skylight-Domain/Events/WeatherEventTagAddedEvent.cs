namespace Skylight.Domain.Events;

public sealed record WeatherEventTagAddedEvent(
	Guid WeatherEventId,
	Guid WeatherEventTagId)
	: DomainEvent;
