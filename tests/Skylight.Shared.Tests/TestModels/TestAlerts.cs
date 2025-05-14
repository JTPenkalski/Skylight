using Skylight.Domain.Alerts.Entities;
using ParameterKeyValue = (Skylight.Domain.Alerts.Entities.AlertParameterKey Key, string Value);

namespace Skylight.Shared.Tests.TestModels;

public static class TestAlerts
{
	/// <summary>
	/// Creates a basic test alert.
	/// </summary>
	public static Alert Default(
		Guid? id = null,
		string? code = null,
		string? externalId = null,
		Zone[]? zones = null,
		ParameterKeyValue[]? parameters = null)
	{
		var alert = new Alert
		{
			Id = id ?? Guid.NewGuid(),
			ExternalId = externalId,
			Type = new()
			{
				ProductCode = code ?? "TST",
				Name = "Test Alert Name",
				Description = "Test Alert Description",
				Level = AlertLevel.Warning,
				EventCode = code ?? "TST",
			},
			Sender = new()
			{
				Code = "SKY",
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
}
