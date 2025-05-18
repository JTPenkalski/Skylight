using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Queries;
using Skylight.Domain.Alerts.Entities;
using Skylight.Shared.Tests.TestModels;

namespace Skylight.Application.Tests.Features.Alerts.Queries;

public class GetCurrentAlertLocationSummaries
{
	private readonly Mock<ISkylightDbContext> dbContext = new();

	private GetCurrentAlertLocationSummariesHandler Handler => new(dbContext.Object);

	[Fact]
	public void GetLocationSummaries_ShouldReturnExpectedZone()
	{
		// Arrange
		var input = new Dictionary<Zone, List<Alert>>()
		{
			[new Zone { Code = "ZN1", Name = "Zone 1" }] =
				[
					TestAlerts.Default(),
				],
			[new Zone { Code = "ZN2", Name = "Zone 2" }] =
				[
					TestAlerts.Default(),
				]
		};

		// Act
		var result = Handler.GetLocationSummaries(input);

		// Assert
		Assert.Equal(input.Count, result.Count);

		Assert.Equal("ZN1", result[0].Code);
		Assert.Equal("Zone 1", result[0].Name);

		Assert.Equal("ZN2", result[1].Code);
		Assert.Equal("Zone 2", result[1].Name);
	}

	[Fact]
	public void GetLocationSummaries_ShouldReturnExpectedTimes()
	{
		// Arrange
		var input = new Dictionary<Zone, List<Alert>>()
		{
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x =>
					{
						x.EffectiveOn = new(2000, 1, 1, 1, 1, 1, TimeSpan.Zero);
						x.ExpiresOn = new(2000, 5, 5, 5, 5, 5, TimeSpan.Zero);
					}),
					TestAlerts.Default().With(x =>
					{
						x.EffectiveOn = new(2000, 3, 3, 3, 3, 3, TimeSpan.Zero);
						x.ExpiresOn = new(2000, 8, 8, 8, 8, 8, TimeSpan.Zero);
					}),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x =>
					{
						x.EffectiveOn = new(2000, 5, 5, 5, 5, 5, TimeSpan.Zero);
						x.ExpiresOn = new(2000, 8, 8, 8, 8, 8, TimeSpan.Zero);
					}),
					TestAlerts.Default().With(x =>
					{
						x.EffectiveOn = new(2000, 1, 1, 1, 1, 1, TimeSpan.Zero);
						x.ExpiresOn = new(2000, 5, 5, 5, 5, 5, TimeSpan.Zero);
					}),
				]
		};

		// Act
		var result = Handler.GetLocationSummaries(input);

		// Assert
		Assert.Equal(input.Count, result.Count);

		Assert.Equal(new(2000, 1, 1, 1, 1, 1, TimeSpan.Zero), result[0].EffectiveTime);
		Assert.Equal(new(2000, 8, 8, 8, 8, 8, TimeSpan.Zero), result[0].ExpirationTime);

		Assert.Equal(new(2000, 1, 1, 1, 1, 1, TimeSpan.Zero), result[1].EffectiveTime);
		Assert.Equal(new(2000, 8, 8, 8, 8, 8, TimeSpan.Zero), result[1].ExpirationTime);
	}

	[Fact]
	public void GetLocationSummaries_ShouldReturnExpectedCounts()
	{
		// Arrange
		var input = new Dictionary<Zone, List<Alert>>()
		{
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.TornadoWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SevereThunderstormWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.FlashFloodWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SpecialWeatherStatement),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.TornadoWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.TornadoWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.TornadoWarning),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SevereThunderstormWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SevereThunderstormWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SevereThunderstormWarning),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.FlashFloodWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.FlashFloodWarning),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.FlashFloodWarning),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SpecialWeatherStatement),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SpecialWeatherStatement),
					TestAlerts.Default().With(x => x.Type.EventCode = AlertTypeCodes.SpecialWeatherStatement),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default().With(x => x.Type.EventCode = "TST"),
				]
		};

		// Act
		var result = Handler.GetLocationSummaries(input);

		// Assert
		Assert.Equal(input.Count, result.Count);

		Assert.Equal(4, result[0].TotalAlerts);
		Assert.Equal(1, result[0].TornadoWarnings);
		Assert.Equal(1, result[0].SevereThunderstormWarnings);
		Assert.Equal(1, result[0].FlashFloodWarnings);
		Assert.Equal(1, result[0].SpecialWeatherStatements);

		Assert.Equal(3, result[1].TotalAlerts);
		Assert.Equal(3, result[1].TornadoWarnings);
		Assert.Equal(0, result[1].SevereThunderstormWarnings);
		Assert.Equal(0, result[1].FlashFloodWarnings);
		Assert.Equal(0, result[1].SpecialWeatherStatements);

		Assert.Equal(3, result[2].TotalAlerts);
		Assert.Equal(0, result[2].TornadoWarnings);
		Assert.Equal(3, result[2].SevereThunderstormWarnings);
		Assert.Equal(0, result[2].FlashFloodWarnings);
		Assert.Equal(0, result[2].SpecialWeatherStatements);

		Assert.Equal(3, result[3].TotalAlerts);
		Assert.Equal(0, result[3].TornadoWarnings);
		Assert.Equal(0, result[3].SevereThunderstormWarnings);
		Assert.Equal(3, result[3].FlashFloodWarnings);
		Assert.Equal(0, result[3].SpecialWeatherStatements);

		Assert.Equal(3, result[4].TotalAlerts);
		Assert.Equal(0, result[4].TornadoWarnings);
		Assert.Equal(0, result[4].SevereThunderstormWarnings);
		Assert.Equal(0, result[4].FlashFloodWarnings);
		Assert.Equal(3, result[4].SpecialWeatherStatements);

		Assert.Equal(1, result[5].TotalAlerts);
		Assert.Equal(0, result[5].TornadoWarnings);
		Assert.Equal(0, result[5].SevereThunderstormWarnings);
		Assert.Equal(0, result[5].FlashFloodWarnings);
		Assert.Equal(0, result[5].SpecialWeatherStatements);
	}

	[Fact]
	public void GetLocationSummaries_ShouldReturnExpectedThreats()
	{
		// Arrange
		var input = new Dictionary<Zone, List<Alert>>()
		{
			[TestZones.Default()] =
				[
					TestAlerts.Default(parameters:
						[
							new(AlertParameterKey.MaxHailSize, "0.88"),
							new(AlertParameterKey.MaxWindGust, "60 MPH"),
							new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.RadarIndicated),
						]),
					TestAlerts.Default(parameters:
						[
							new(AlertParameterKey.MaxHailSize, "Up to .75"),
							new(AlertParameterKey.MaxWindGust, "70 MPH"),
							new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.RadarIndicated),
							new(AlertParameterKey.TornadoDetection, AlertParameterValues.Possible),
						]),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default(parameters:
						[
							new(AlertParameterKey.MaxHailSize, "2.00"),
							new(AlertParameterKey.MaxWindGust, "80 MPH"),
							new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
						]),
					TestAlerts.Default(parameters:
						[
							new(AlertParameterKey.MaxHailSize, ".88"),
							new(AlertParameterKey.MaxWindGust, "Up to 40 MPH"),
							new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.RadarIndicated),
						]),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default(parameters: []).With(x => x.Type.Level = AlertLevel.Advisory),
				],
			[TestZones.Default()] =
				[
					TestAlerts.Default(parameters:
						[
							new(AlertParameterKey.MaxHailSize, "2.00"),
							new(AlertParameterKey.MaxWindGust, "80 MPH"),
							new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
							new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
						]),
					TestAlerts.Default(parameters:
						[
							new(AlertParameterKey.MaxHailSize, "Up to .88"),
							new(AlertParameterKey.MaxWindGust, "40 MPH"),
							new(AlertParameterKey.TornadoDetection, AlertParameterValues.Observed),
							new(AlertParameterKey.ThunderstormThreat, AlertParameterValues.Observed),
							new(AlertParameterKey.ThunderstormDamageThreat, AlertParameterValues.Destructive),
						]),
				],
		};

		// Act
		var result = Handler.GetLocationSummaries(input);

		// Assert
		Assert.Equal(input.Count, result.Count);

		Assert.Equal(0.88f, result[0].MaxHail);
		Assert.Equal(70f, result[0].MaxWind);
		Assert.True(result[0].Tornadoes);
		Assert.Equal(AlertThreat.RadarIndicated, result[0].MaxThreat);

		Assert.Equal(2f, result[1].MaxHail);
		Assert.Equal(80f, result[1].MaxWind);
		Assert.False(result[1].Tornadoes);
		Assert.Equal(AlertThreat.Observed, result[1].MaxThreat);

		Assert.Equal(0f, result[2].MaxHail);
		Assert.Equal(0f, result[2].MaxWind);
		Assert.False(result[2].Tornadoes);
		Assert.Equal(AlertThreat.Unknown, result[2].MaxThreat);

		Assert.Equal(2f, result[3].MaxHail);
		Assert.Equal(80f, result[3].MaxWind);
		Assert.True(result[3].Tornadoes);
		Assert.Equal(AlertThreat.PDS, result[3].MaxThreat);
	}
}
