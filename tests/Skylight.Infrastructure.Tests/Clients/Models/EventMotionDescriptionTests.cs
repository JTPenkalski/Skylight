using Skylight.Infrastructure.Clients.NationalWeatherService.Models;
using Skylight.Shared.Tests.TestData;

namespace Skylight.Infrastructure.Tests.Clients.Models;

public class EventMotionDescriptionTests
{
	[Theory]
	[ClassData(typeof(StringNullOrWhiteSpaceTestData))]
	public void Parse_ShouldReturnNull_WhenGivenNullOrWhitespace(string? value)
	{
		// Act
		EventMotionDescription? result = EventMotionDescription.Parse(value);

		// Assert
		Assert.Null(result);
	}

	[Fact]
	public void Parse_ShouldCreateType_WhenGivenSingleLatLon()
	{
		// Arrange
		string value = "2025-05-04T10:20:30-00:00...storm...196DEG...23KT...12.34,-100.20";

		// Act
		EventMotionDescription result = EventMotionDescription.Parse(value);

		// Assert
		Assert.Equal(new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero), result.Time);
		Assert.Equal("storm", result.Event);
		Assert.Equal("196DEG", result.Degrees);
		Assert.Equal("23KT", result.Speed);
		Assert.Equal("12.34,-100.20", result.LatLon);
	}

	[Fact]
	public void Parse_ShouldCreateType_WhenGivenMultipleLatLon()
	{
		// Arrange
		string value = "2025-05-04T10:20:30-00:00...storm...196DEG...23KT...12.34,-100.20,-56.78,80.90";

		// Act
		EventMotionDescription result = EventMotionDescription.Parse(value);

		// Assert
		Assert.Equal(new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero), result.Time);
		Assert.Equal("storm", result.Event);
		Assert.Equal("196DEG", result.Degrees);
		Assert.Equal("23KT", result.Speed);
		Assert.Equal("12.34,-100.20,-56.78,80.90", result.LatLon);
	}

	[Fact]
	public void ToString_ShouldReturnStringRepresentation()
	{
		// Arrange
		var eventMotionDescription = new EventMotionDescription(
			new DateTimeOffset(2025, 5, 4, 10, 20, 30, TimeSpan.Zero),
			"storm",
			"196DEG",
			"23KT",
			"12.34,-100.20,-56.78,80.90");

		// Act
		string result = eventMotionDescription.ToString();

		// Assert
		Assert.Equal("2025-05-04T10:20:30.0000000+00:00...storm...196DEG...23KT...12.34,-100.20,-56.78,80.90", result);
	}
}
