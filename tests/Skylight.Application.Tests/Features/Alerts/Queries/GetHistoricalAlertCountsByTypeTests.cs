using Skylight.Application.Data;
using Skylight.Application.Features.Alerts.Queries;

namespace Skylight.Application.Tests.Features.Alerts.Queries;

public class GetHistoricalAlertCountsByTypeTests
{
	private readonly Mock<ISkylightDbContext> dbContext = new();

	private GetHistoricalAlertCountsByTypeHandler Handler => new(dbContext.Object);

	#region GetHistoricalAlertCounts

	public record GetHistoricalAlertCountsTestCase(
		DateTimeOffset MinTime,
		DateTimeOffset MaxTime,
		List<GetHistoricalAlertCountsByTypeHandler.AlertSpan> Spans,
		List<GetHistoricalAlertCountsByTypeResponse.HistoricalAlertCount> ExpectedResult);

	public class GetHistoricalAlertCountsTests : TheoryData<GetHistoricalAlertCountsTestCase>
	{
		public GetHistoricalAlertCountsTests()
		{
			/*
			*			MIN					MAX
			*	*-------|-----*				|
			*		*---|---------*			|
			*			|	*------------*	|
			*			|			*-------|-----*
			*			|				*---|---------*
			*/
			Add(
				new GetHistoricalAlertCountsTestCase(
					new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero),
					new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero),
					[
						new(new(2000, 1, 1, 4, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 8, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 5, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 9, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 7, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 12, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 10, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 15, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 11, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 16, 0, 0, TimeSpan.Zero)),
					],
					[
						new(new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 7, 0, 0, TimeSpan.Zero), 3),
						new(new(2000, 1, 1, 8, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 9, 0, 0, TimeSpan.Zero), 1),
						new(new(2000, 1, 1, 10, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 11, 0, 0, TimeSpan.Zero), 3),
						new(new(2000, 1, 1, 12, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero), 2),
					]));

			/*
			*		MIN					MAX
			*	*---|---*				|
			*		*-------------------*
			*		|		*---*		|
			*		|				*---|---*
			*/
			Add(
				new GetHistoricalAlertCountsTestCase(
					new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero),
					new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero),
					[
						new(new(2000, 1, 1, 5, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 7, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 8, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 10, 0, 0, TimeSpan.Zero)),
						new(new(2000, 1, 1, 12, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 16, 0, 0, TimeSpan.Zero)),
					],
					[
						new(new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 7, 0, 0, TimeSpan.Zero), 1),
						new(new(2000, 1, 1, 8, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 10, 0, 0, TimeSpan.Zero), 1),
						new(new(2000, 1, 1, 12, 0, 0, TimeSpan.Zero), 2),
						new(new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero), 2),
					]));

			/*
			*		MIN					MAX
			*		|		*---*		|
			*/
			Add(
				new GetHistoricalAlertCountsTestCase(
					new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero),
					new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero),
					[
						new(new(2000, 1, 1, 8, 0, 0, TimeSpan.Zero), new(2000, 1, 1, 10, 0, 0, TimeSpan.Zero)),
					],
					[
						new(new(2000, 1, 1, 6, 0, 0, TimeSpan.Zero), 0),
						new(new(2000, 1, 1, 8, 0, 0, TimeSpan.Zero), 1),
						new(new(2000, 1, 1, 10, 0, 0, TimeSpan.Zero), 0),
						new(new(2000, 1, 1, 14, 0, 0, TimeSpan.Zero), 0),
					]));
		}
	}

	[Theory]
	[ClassData(typeof(GetHistoricalAlertCountsTests))]
	public void GetHistoricalAlertCounts_ShouldReturnOrderedList(GetHistoricalAlertCountsTestCase test)
	{
		// Act
		var result = Handler.GetHistoricalAlertCounts(test.MinTime, test.MaxTime, test.Spans);

		// Assert
		Assert.Equal(test.ExpectedResult, result);
	}

	#endregion
}
