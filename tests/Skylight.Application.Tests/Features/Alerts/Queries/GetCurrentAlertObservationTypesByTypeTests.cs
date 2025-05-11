using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Queries;
using Skylight.Domain.Alerts.Entities;
using Skylight.Shared.Tests.TestModels;

namespace Skylight.Application.Tests.Features.Alerts.Queries;

public class GetCurrentAlertObservationTypesByTypeTests
{
	private readonly Mock<ISkylightDbContext> dbContext = new();

	private GetCurrentAlertObservationTypesByTypeHandler Handler => new(dbContext.Object);

	#region GetObservationTypeCounts

	[Fact]
	public void GetObservationTypeCounts_ShouldReturnObservationTypes_WhenGivenThunderstorms()
	{
		// Arrange
		List<Alert> alerts =
		[
			TestAlerts.SevereThunderstormWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "RADAR INDICATED"),
					(AlertParameterKey.WindThreat, "OBSERVED"),
				]),
			TestAlerts.SevereThunderstormWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "OBSERVED"),
					(AlertParameterKey.WindThreat, "RADAR INDICATED"),
				]),
			TestAlerts.SevereThunderstormWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "RADAR INDICATED"),
					(AlertParameterKey.WindThreat, "RADAR INDICATED"),
					(AlertParameterKey.ThunderstormDamageThreat, "CONSIDERABLE"),
				]),
			TestAlerts.SevereThunderstormWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "OBSERVED"),
					(AlertParameterKey.WindThreat, "OBSERVED"),
					(AlertParameterKey.ThunderstormDamageThreat, "CONSIDERABLE"),
				]),
		];

		// Act
		var result = Handler.GetObservationTypeCounts(alerts);

		// Assert
		Assert.Equal(3, result.Count);
		Assert.Equal(1, result.Single(x => x.ObservationType == "RADAR INDICATED").Count);
		Assert.Equal(1, result.Single(x => x.ObservationType == "OBSERVED").Count);
		Assert.Equal(2, result.Single(x => x.ObservationType == "CONSIDERABLE").Count);
	}

	[Fact]
	public void GetObservationTypeCounts_ShouldReturnObservationTypes_WhenGivenTornadoes()
	{
		// Arrange
		List<Alert> alerts =
		[
			TestAlerts.TornadoWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "RADAR INDICATED"),
					(AlertParameterKey.WindThreat, "OBSERVED"),
				]),
			TestAlerts.TornadoWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "OBSERVED"),
					(AlertParameterKey.WindThreat, "RADAR INDICATED"),
				]),
			TestAlerts.TornadoWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "RADAR INDICATED"),
					(AlertParameterKey.WindThreat, "RADAR INDICATED"),
					(AlertParameterKey.TornadoDetection, "OBSERVED"),
				]),
			TestAlerts.TornadoWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "OBSERVED"),
					(AlertParameterKey.WindThreat, "OBSERVED"),
					(AlertParameterKey.TornadoDetection, "RADAR INDICATED"),
				]),
			TestAlerts.TornadoWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "RADAR INDICATED"),
					(AlertParameterKey.WindThreat, "RADAR INDICATED"),
					(AlertParameterKey.TornadoDetection, "RADAR INDICATED"),
					(AlertParameterKey.TypeModifier, "PDS"),
				]),
			TestAlerts.TornadoWarning(
				parameters:
				[
					(AlertParameterKey.HailThreat, "OBSERVED"),
					(AlertParameterKey.WindThreat, "OBSERVED"),
					(AlertParameterKey.TornadoDetection, "OBSERVED"),
					(AlertParameterKey.TypeModifier, "EMERGENCY"),
				]),
		];

		// Act
		var result = Handler.GetObservationTypeCounts(alerts);

		// Assert
		Assert.Equal(4, result.Count);
		Assert.Equal(2, result.Single(x => x.ObservationType == "RADAR INDICATED").Count);
		Assert.Equal(2, result.Single(x => x.ObservationType == "OBSERVED").Count);
		Assert.Equal(1, result.Single(x => x.ObservationType == "PDS").Count);
		Assert.Equal(1, result.Single(x => x.ObservationType == "EMERGENCY").Count);
	}

	#endregion
}
