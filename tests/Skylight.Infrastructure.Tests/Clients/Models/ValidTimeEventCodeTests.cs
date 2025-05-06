using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using Skylight.Shared.Tests.TestData;

namespace Skylight.Infrastructure.Tests.Clients.Models;

public class ValidTimeEventCodeTests
{
	[Theory]
	[ClassData(typeof(StringNullOrWhiteSpaceTestData))]
	public void Parse_ShouldReturnNull_WhenGivenNullOrWhitespace(string? value)
	{
		// Act
		ValidTimeEventCode? result = ValidTimeEventCode.Parse(value);

		// Assert
		Assert.Null(result);
	}

	[Fact]
	public void Parse_ShouldCreateType()
	{
		// Arrange
		string value = "/O.NEW.KCTP.SV.A.0123.250504T2205Z-250506T0030Z/";

		// Act
		ValidTimeEventCode result = ValidTimeEventCode.Parse(value);

		// Assert
		Assert.Equal("O", result.ProductClass);
		Assert.Equal("NEW", result.Action);
		Assert.Equal("KCTP", result.OfficeId);
		Assert.Equal("SV", result.Phenomena);
		Assert.Equal("A", result.Significance);
		Assert.Equal("0123", result.EventNumber);
		Assert.Equal("250504T2205Z", result.EventBeginDate);
		Assert.Equal("250506T0030Z", result.EventEndDate);
	}

	[Fact]
	public void ToString_ShouldReturnStringRepresentation()
	{
		// Arrange
		var vtec = new ValidTimeEventCode(
			"O",
			"NEW",
			"KCTP",
			"SV",
			"A",
			"0123",
			"250504T2205Z",
			"250506T0030Z");

		// Act
		string result = vtec.ToString();

		// Assert
		Assert.Equal("/O.NEW.KCTP.SV.A.0123.250504T2205Z-250506T0030Z/", result);
	}
}
