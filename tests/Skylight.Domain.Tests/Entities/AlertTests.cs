using Skylight.Domain.Alerts.Entities;
using Skylight.Shared.Tests.TestModels;

namespace Skylight.Domain.Tests.Entities;

public class AlertTests
{
	public static TheoryData<(AlertParameterKey, string)[], string> ObservationType_ShouldReturnExpectedType_TestData =>
		new()
		{
			// TOR EMERGENCY
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDamageThreat, AlertParameterValues.Catastrophic),
				],
				"Catastrophic"
			},

			// TOR PDS
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDamageThreat, AlertParameterValues.Considerable),
				],
				"Considerable"
			},

			// TOR OBSERVED
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
				],
				"Observed"
			},

			// TOR RADAR INDICATED
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.RadarIndicated),
				],
				"Radar Indicated"
			},

			// SVR DESTRUCTIVE
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
					(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Destructive),
				],
				"Destructive"
			},

			// SVR CONSIDERABLE
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
					(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Considerable),
				],
				"Considerable"
			},

			// SVR OBSERVED
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
				],
				"Observed"
			},

			// SVR RADAR INDICATED
			{
				[
					(AlertParameterKey.ThunderstormThreat, AlertParameterValues.RadarIndicated),
					(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
				],
				"Radar Indicated"
			},

			// FFW CATASTROPHIC
			{
				[
					(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
					(AlertParameterKey.FlashFloodDamageThreat, AlertParameterValues.Catastrophic),
				],
				"Catastrophic"
			},

			// FFW CONSIDERABLE
			{
				[
					(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
					(AlertParameterKey.FlashFloodDamageThreat, AlertParameterValues.Considerable),
				],
				"Considerable"
			},

			// FFW OBSERVED
			{
				[
					(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
				],
				"Observed"
			},

			// FFW RADAR AND GAUGE INDICATED
			{
				[
					(AlertParameterKey.FlashFloodDetection, AlertParameterValues.RadarAndGaugeIndicated),
				],
				"Radar And Gauge Indicated"
			},

			// FFW RADAR INDICATED
			{
				[
					(AlertParameterKey.FlashFloodDetection, AlertParameterValues.RadarIndicated),
				],
				"Radar Indicated"
			},
		};

	[Theory]
	[MemberData(nameof(ObservationType_ShouldReturnExpectedType_TestData))]
	public void ObservationType_ShouldReturnExpectedType_WhenGivenParameters((AlertParameterKey, string)[] parameters, string expectedType)
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
