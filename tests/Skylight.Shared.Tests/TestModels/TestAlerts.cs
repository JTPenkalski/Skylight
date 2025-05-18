using Skylight.Domain.Alerts.Entities;

namespace Skylight.Shared.Tests.TestModels;

public static class TestAlerts
{
	/// <summary>
	/// Modifies an <see cref="Alert"/> in-place, for easier instantiation in tests.
	/// </summary>
	/// <param name="modifier">The modifications to make to <paramref name="alert"/>.</param>
	/// <returns>The modified alert.</returns>
	public static Alert With(this Alert alert, Action<Alert> modifier)
	{
		modifier(alert);

		return alert;
	}

	/// <summary>
	/// Creates a basic test <see cref="Alert"/>.
	/// </summary>
	public static Alert Default(
		Guid? id = null,
		string? externalId = null,
		Zone[]? zones = null,
		AlertParameterKeyValue[]? parameters = null)
	{
		var alert = new Alert
		{
			Id = id ?? Guid.NewGuid(),
			ExternalId = externalId,
			Type = new()
			{
				ProductCode = "TST",
				Name = "Test Alert Name",
				Description = "Test Alert Description",
				Level = AlertLevel.Warning,
				EventCode = "TST",
			},
			Sender = new()
			{
				Code = "SKY",
				Name = "Test Sender",
			},
			Headline = "Test Headline",
			Description = "Test Description",
			Instruction = "Test Instruction",
			SentOn = new(2000, 1, 1, 1, 1, 1, TimeSpan.Zero),
			EffectiveOn = new(2000, 1, 1, 2, 2, 2, TimeSpan.Zero),
			BeginsOn = new(2000, 1, 1, 3, 3, 3, TimeSpan.Zero),
			ExpiresOn = new(2000, 1, 1, 4, 4, 4, TimeSpan.Zero),
			EndsOn = new(2000, 1, 1, 5, 5, 5, TimeSpan.Zero),
			MessageType = AlertMessageType.Alert,
			Severity = AlertSeverity.Extreme,
			Certainty = AlertCertainty.Observed,
			Urgency = AlertUrgency.Immediate,
			Response = AlertResponse.Shelter,
		};

		foreach (Zone zone in zones ?? [TestZones.Default()])
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
