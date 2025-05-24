using Skylight.Domain.Alerts.Entities;
using Skylight.Shared.Tests.TestModels;

namespace Skylight.Domain.Tests.Entities;

public class AlertTests
{
	public static TheoryData<AlertParameterKeyValue[], string> ObservationType_ShouldReturnExpectedType_TestData =>
		new()
		{
			// TOR EMERGENCY
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDamageThreat, AlertParameterValues.Catastrophic),
				],
				"Catastrophic"
			},

			// TOR PDS
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDamageThreat, AlertParameterValues.Considerable),
				],
				"Considerable"
			},

			// TOR OBSERVED
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
				],
				"Observed"
			},

			// TOR RADAR INDICATED
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.RadarIndicated),
				],
				"Radar Indicated"
			},

			// SVR DESTRUCTIVE
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
					new(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Destructive),
				],
				"Destructive"
			},

			// SVR CONSIDERABLE
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
					new(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Considerable),
				],
				"Considerable"
			},

			// SVR OBSERVED
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
				],
				"Observed"
			},

			// SVR RADAR INDICATED
			{
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.RadarIndicated),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
				],
				"Radar Indicated"
			},

			// FFW CATASTROPHIC
			{
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.FlashFloodDamageThreat, AlertParameterValues.Catastrophic),
				],
				"Catastrophic"
			},

			// FFW CONSIDERABLE
			{
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.FlashFloodDamageThreat, AlertParameterValues.Considerable),
				],
				"Considerable"
			},

			// FFW OBSERVED
			{
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
				],
				"Observed"
			},

			// FFW RADAR AND GAUGE INDICATED
			{
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.RadarAndGaugeIndicated),
				],
				"Radar And Gauge Indicated"
			},

			// FFW RADAR INDICATED
			{
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.RadarIndicated),
				],
				"Radar Indicated"
			},
		};

	[Theory]
	[MemberData(nameof(ObservationType_ShouldReturnExpectedType_TestData))]
	public void ObservationType_ShouldReturnExpectedType_WhenGivenParameters(AlertParameterKeyValue[] parameters, string expectedType)
	{
		// Arrange
		var alert = TestAlerts.Default(parameters: parameters);

		// Act
		string result = alert.ObservationType;

		// Assert
		Assert.Equal(expectedType, result);
	}

	[Fact]
	public void ObservationType_ShouldReturnExpectedType_WhenGivenNoParameters()
	{
		// Arrange
		var alert = TestAlerts.Default();

		// Act
		string result = alert.ObservationType;

		// Assert
		Assert.Equal(alert.Type.Level.ToString(), result);
	}
}
