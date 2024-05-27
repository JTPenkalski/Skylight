using Skylight.Infrastructure.Clients.NationalWeatherService.Models;

namespace Skylight.Infrastructure.Clients.NationalWeatherService.Actions;

public sealed record GetActiveAlertsRequest(
	AlertStatus[]? Statuses = null,
	AlertMessageType[]? MessageTypes = null,
	string[]? EventNames = null,
	string[]? EventCodes = null,
	AlertLocation? Location = null,
	AlertUrgency[]? Urgencies = null,
	AlertSeverity[]? Severities = null,
	AlertCertainty[]? Certainties = null,
	int Limit = 100)
	: IClientRequest;

public sealed record GetActiveAlertsResponse(AlertCollection AlertCollection)
	: IClientResponse;
