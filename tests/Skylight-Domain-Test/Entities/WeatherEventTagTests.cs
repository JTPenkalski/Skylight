using Skylight.Domain.Entities;

namespace Skylight.Tests.Domain.Entities;

public class WeatherEventTagTests
{
	[Fact]
	public void Votes_Should_BePositive()
	{
		// Arrange
		var weatherEventTag = new WeatherEventTag
		{
			Event = null!,
			Tag = null!,
		};

		// Act
		weatherEventTag.Votes += -1;

		// Assert
		Assert.Equal(0, weatherEventTag.Votes);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, false)]
	[InlineData(3, true)]
	[InlineData(4, true)]
	public void Votes_Should_SetEffectiveDate(int votes, bool expectedEffective)
	{
		// Arrange
		var weatherEventTag = new WeatherEventTag
		{ 
			Event = null!,
			Tag = null!,
		};

		// Act
		weatherEventTag.Votes += votes;

		// Assert
		Assert.Equal(expectedEffective, weatherEventTag.EffectiveDate.HasValue);
		Assert.Equal(votes, weatherEventTag.Votes);
	}
}
