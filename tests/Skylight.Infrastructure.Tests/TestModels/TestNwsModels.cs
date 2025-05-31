using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using Core = Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Tests.TestModels;

public static class TestNwsModels
{
	/// <summary>
	/// Creates a basic test alert.
	/// </summary>
	public static Alert Alert()
	{
		var alert = new Alert(
			Id: "Id",
			AreaDescription: "Area Description",
			Zones: [],
			Sent: new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero),
			Effective: new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero),
			Onset: new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero),
			Expires: new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero),
			Ends: new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero),
			Status: AlertStatus.Test,
			MessageType: AlertMessageType.Alert,
			Severity: AlertSeverity.Unknown,
			Category: AlertCategory.Met,
			Urgency: AlertUrgency.Unknown,
			Certainty: AlertCertainty.Unknown,
			Event: "Test Alert",
			SenderName: "TST",
			Headline: "Headline",
			Description: "Description",
			Instruction: "Instruction",
			Response: AlertResponse.None,
			AwipsId: new AwipsIdentifier("TST", "TST"),
			EventMotionDescription: new EventMotionDescription(new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero), "001", "000DEG", "00KT", "0,0"),
			WindThreat: Core.AlertParameterValues.RadarIndicated,
			MaxWindGust: "60",
			HailThreat: Core.AlertParameterValues.RadarIndicated,
			MaxHailSize: "1.00",
			ThunderstormDamageThreat: default,
			TornadoDetection: default,
			TornadoDamageThreat: default,
			FlashFloodDetection: default,
			FlashFloodDamageThreat: default,
			SnowSquallDetection: default,
			SnowSquallImpact: default,
			WaterspoutDetection: default,
			ValidTimeEventCode: new ValidTimeEventCode("TST", "NEW", "TST", "TS", "T", "0001", "2025-05-04", "2025-05-04"),
			EventEndingTime: new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero));

		return alert;
	}
}
