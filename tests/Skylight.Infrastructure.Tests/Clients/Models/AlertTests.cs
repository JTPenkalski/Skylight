using Skylight.Domain.Alerts.Entities;
using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using Skylight.Infrastructure.Tests.TestModels;

namespace Skylight.Infrastructure.Tests.Clients.Models;

public class AlertTests
{
	[Fact]
	public void TypeCode_ShouldReturnEventCode_WhenEventCodeNotNull()
	{
		// Arrange
		var alert = TestNwsModels.Alert() with
		{
			AwipsId = new AwipsIdentifier("ERR", string.Empty),
			ValidTimeEventCode = new ValidTimeEventCode(
				string.Empty,
				string.Empty,
				string.Empty,
				"TS",
				"T",
				string.Empty,
				string.Empty,
				string.Empty)
		};

		// Act
		string result = alert.TypeCode;

		// Assert
		Assert.Equal("TST", result);
	}

	[Fact]
	public void TypeCode_ShouldReturnProductCode_WhenEventCodeNull()
	{
		// Arrange
		var alert = TestNwsModels.Alert() with
		{
			AwipsId = new AwipsIdentifier("TST", string.Empty),
			ValidTimeEventCode = null,
		};

		// Act
		string result = alert.TypeCode;

		// Assert
		Assert.Equal("TST", result);
	}

	[Theory]
	[InlineData(AlertParameterValues.Observed, AlertParameterValues.RadarIndicated, AlertParameterValues.Observed)]
	[InlineData(AlertParameterValues.RadarIndicated, AlertParameterValues.Observed, AlertParameterValues.Observed)]
	[InlineData(AlertParameterValues.RadarIndicated, AlertParameterValues.RadarIndicated, AlertParameterValues.RadarIndicated)]
	[InlineData(AlertParameterValues.Observed, null, AlertParameterValues.Observed)]
	[InlineData(null, AlertParameterValues.Observed, AlertParameterValues.Observed)]
	[InlineData(AlertParameterValues.RadarIndicated, null, AlertParameterValues.RadarIndicated)]
	[InlineData(null, AlertParameterValues.RadarIndicated, AlertParameterValues.RadarIndicated)]
	[InlineData(null, null, null)]
	public void ThunderstormThreat_ShouldReturnExpectedType(string? hailThreat, string? windThreat, string? expectedType)
	{
		// Arrange
		var alert = TestNwsModels.Alert() with
		{
			HailThreat = hailThreat,
			WindThreat = windThreat,
		};

		// Act
		string? result = alert.ThunderstormThreat;

		// Assert
		Assert.Equal(expectedType, result);
	}
}
