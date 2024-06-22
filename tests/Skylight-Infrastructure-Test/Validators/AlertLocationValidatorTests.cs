using Skylight.Infrastructure.Clients.NationalWeatherService.Models;

namespace Skylight.Tests.Infrastructure.Validators;

public class AlertLocationValidatorTests
{
	#region AreaAlertLocation

	[Fact]
	public void AreaAlertLocationValidator_Should_SucceedWithStateCode()
	{
		// Arrange
		var location = new AreaAlertLocation(StateCodes: [StateTerritoryCode.WI]);

		var validator = new AreaAlertLocationValidator();

		// Act
		var result = validator.TestValidate(location);

		// Assert
		Assert.True(result.IsValid);
	}

	[Fact]
	public void AreaAlertLocationValidator_Should_SucceedWithMarineCode()
	{
		// Arrange
		var location = new AreaAlertLocation(MarineCodes: [MarineAreaCode.LM]);

		var validator = new AreaAlertLocationValidator();

		// Act
		var result = validator.TestValidate(location);

		// Assert
		Assert.True(result.IsValid);
	}

	[Fact]
	public void AreaAlertLocationValidator_Should_ErrorWhenBothCodesUsed()
	{
		// Arrange
		var location = new AreaAlertLocation(
			StateCodes: [StateTerritoryCode.WI],
			MarineCodes: [MarineAreaCode.LM]);
		
		var validator = new AreaAlertLocationValidator();

		// Act
		var result = validator.TestValidate(location);

		// Assert
		Assert.False(result.IsValid);
	}

	#endregion

	#region ZoneAlertLocation

	public static TheoryData<string[], bool> ZoneAlertLocationValidator_Should_ValidateZoneIds_TestData =>
		new()
		{
			{ ["ARC133"], true },
			{ ["A"], false },
			{ ["ARC133", "A"], false },
		};

	[Theory]
	[MemberData(nameof(ZoneAlertLocationValidator_Should_ValidateZoneIds_TestData))]
	public void ZoneAlertLocationValidator_Should_ValidateZoneIds(string[] zoneIds, bool expectedValid)
	{
		// Arrange
		var location = new ZoneAlertLocation(ZoneIds: zoneIds);

		var validator = new ZoneAlertLocationValidator();

		// Act
		var result = validator.TestValidate(location);

		// Assert
		Assert.Equal(expectedValid, result.IsValid);
	}

	#endregion
}
