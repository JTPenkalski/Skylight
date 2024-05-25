﻿namespace Skylight.Application.Interfaces.Infrastructure.Clients.NationalWeatherService;

public sealed record GetActiveAlertsRequest(
    AlertStatus? Status = null,
    AlertMessageType? MessageType = null,
    string? EventName = null,
    string? EventCode = null,
    AlertLocation? Location = null,
    AlertUrgency? Urgency = null,
    AlertSeverity? Severity = null,
    AlertCertainty? Certainty = null,
    int Limit = 100);

public sealed record GetActiveAlertsResponse(AlertCollection AlertCollection);
