using Skylight.Application.Alerts.Queries;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;
using Skylight.Shared.Tests.TestModels;

namespace Skylight.Application.Tests.Features.Alerts.Queries;

public class GetCurrentAlertObservationTypesByTypeTests
{
	private readonly Mock<ISkylightDbContext> dbContext = new();

	private GetCurrentAlertObservationTypesByTypeHandler Handler => new(dbContext.Object);

	#region GetObservationTypeCounts

	[Fact]
	public void GetObservationTypeCounts_ShouldReturnObservationTypeCounts()
	{
		// Arrange
		List<Alert> alerts =
		[
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDamageThreat, AlertParameterValues.Catastrophic),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDamageThreat, AlertParameterValues.Considerable),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.RadarIndicated),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
					new(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Destructive),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
					new(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Considerable),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.RadarIndicated),
					new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.FlashFloodDamageThreat, AlertParameterValues.Catastrophic),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
					new(AlertParameterKey.FlashFloodDamageThreat, AlertParameterValues.Considerable),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.Observed),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.RadarAndGaugeIndicated),
				]),
			TestAlerts.Default(
				parameters:
				[
					new(AlertParameterKey.FlashFloodDetection, AlertParameterValues.RadarIndicated),
				])
		];

		// Act
		var result = Handler.GetObservationTypeCounts(alerts);

		// Assert
		Assert.Equal(6, result.Count);
		Assert.Equal(2, result.Single(x => x.ObservationType == "Catastrophic").Count);
		Assert.Equal(1, result.Single(x => x.ObservationType == "Destructive").Count);
		Assert.Equal(3, result.Single(x => x.ObservationType == "Considerable").Count);
		Assert.Equal(3, result.Single(x => x.ObservationType == "Observed").Count);
		Assert.Equal(3, result.Single(x => x.ObservationType == "Radar Indicated").Count);
		Assert.Equal(1, result.Single(x => x.ObservationType == "Radar And Gauge Indicated").Count);
	}

	#endregion
}
