using Skylight.Infrastructure.Clients.NationalWeatherService.Actions;

namespace Skylight.Tests.Infrastructure.Validators;

public class GetActiveAlertsValidatorTests
{
	#region Request

	[Theory]
	[InlineData(-1, false)]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void GetActiveAlertsRequestValidator_Should_ValidateLimit(int limit, bool expectedValid)
	{
		// Arrange
		var request = new GetActiveAlertsRequest(Limit: limit);

		var validator = new GetActiveAlertsRequestValidator();

		// Act
		var result = validator.TestValidate(request);

		// Assert
		Assert.Equal(expectedValid, result.IsValid);
	}

	public static TheoryData<string[], bool> ZoneAlertLocationValidator_Should_ValidateEventCodes_TestData =>
		new()
		{
			{ ["ABC"], true },
			{ ["A"], false },
			{ ["ABC", "A"], false },
		};

	[Theory]
	[MemberData(nameof(ZoneAlertLocationValidator_Should_ValidateEventCodes_TestData))]
	public void ZoneAlertLocationValidator_Should_ValidateEventCodes(string[] eventCodes, bool expectedValid)
	{
		// Arrange
		var request = new GetActiveAlertsRequest(EventCodes: eventCodes);

		var validator = new GetActiveAlertsRequestValidator();

		// Act
		var result = validator.TestValidate(request);

		// Assert
		Assert.Equal(expectedValid, result.IsValid);
	}

	#endregion
}
