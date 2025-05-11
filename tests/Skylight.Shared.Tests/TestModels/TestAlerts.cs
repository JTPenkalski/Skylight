using Skylight.Domain.Alerts.Entities;
using AlertParameter = (Skylight.Domain.Alerts.Entities.AlertParameterKey Key, string Value);

namespace Skylight.Shared.Tests.TestModels;

public static class TestAlerts
{
	/// <summary>
	/// Creates a test SVR alert.
	/// </summary>
	public static Alert SevereThunderstormWarning(Zone[]? zones = null, AlertParameter[]? parameters = null)
	{
		var alert = new Alert
		{
			Type = new()
			{
				ProductCode = "SVR",
				Name = "Severe Thunderstorm Warning",
				Description = "Test Description",
				Level = AlertLevel.Warning,
				EventCode = "SVW",
			},
			Sender = new()
			{
				Code = "AAA",
				Name = "Test Sender",
			},
			Headline = "Test Headline",
			Description = "Test Description",
			Instruction = "Test Instruction",
			SentOn = DateTimeOffset.UtcNow,
			EffectiveOn = DateTimeOffset.UtcNow,
			BeginsOn = DateTimeOffset.UtcNow,
			ExpiresOn = DateTimeOffset.UtcNow,
			EndsOn = DateTimeOffset.UtcNow,
			MessageType = AlertMessageType.Alert,
			Severity = AlertSeverity.Extreme,
			Certainty = AlertCertainty.Observed,
			Urgency = AlertUrgency.Immediate,
			Response = AlertResponse.Shelter,
		};

		foreach (Zone zone in zones ?? [])
		{
			alert.AddZone(zone);
		}

		foreach (var (Key, Value) in parameters ?? [])
		{
			alert.AddParameter(Key, Value);
		}

		return alert;
	}

	/// <summary>
	/// Creates a test TOR alert.
	/// </summary>
	public static Alert TornadoWarning(Zone[]? zones = null, AlertParameter[]? parameters = null)
	{
		var alert = new Alert
		{
			Type = new()
			{
				ProductCode = "TOR",
				Name = "Tornado Warning",
				Description = "Test Description",
				Level = AlertLevel.Warning,
				EventCode = "SVW",
			},
			Sender = new()
			{
				Code = "AAA",
				Name = "Test Sender",
			},
			Headline = "Test Headline",
			Description = "Test Description",
			Instruction = "Test Instruction",
			SentOn = DateTimeOffset.UtcNow,
			EffectiveOn = DateTimeOffset.UtcNow,
			BeginsOn = DateTimeOffset.UtcNow,
			ExpiresOn = DateTimeOffset.UtcNow,
			EndsOn = DateTimeOffset.UtcNow,
			MessageType = AlertMessageType.Alert,
			Severity = AlertSeverity.Extreme,
			Certainty = AlertCertainty.Observed,
			Urgency = AlertUrgency.Immediate,
			Response = AlertResponse.Shelter,
		};

		foreach (Zone zone in zones ?? [])
		{
			alert.AddZone(zone);
		}

		foreach (AlertParameter parameter in parameters ?? [])
		{
			alert.AddParameter(parameter.Key, parameter.Value);
		}

		return alert;
	}
}
