using Skylight.Application.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Initializers;

public class DefaultSkylightDbContextInitializer(ISkylightDbContext dbContext) : ISkylightDbContextInitializer
{
	public async Task InitializeAsync()
	{
		await dbContext.ResetAsync();

		await AddAlertTypesAsync();

		await dbContext.CommitAsync();
	}

	private async Task AddAlertTypesAsync()
	{
		AlertType[] alertTypes =
		[
			new()
			{
				Code = "FFW",
				Name = "Flash Flood Warning",
				Description = "Issued to inform the public, emergency management, and other cooperating agencies that flash flooding is in progress, imminent, or highly likely.",
				Level = Level.Warning,
			},
			new()
			{
				Code = "FFA",
				Name = "Flash Flood Watch",
				Description = "Issued to indicate current or developing hydrologic conditions that are favorable for flash flooding in and close to the watch area, but the occurrence is neither certain or imminent.",
				Level = Level.Watch,
			},
			new()
			{
				Code = "FFS",
				Name = "Flash Flood Statement",
				Description = "In hydrologic terms, a statement by the NWS which provides follow-up information on flash flood watches and warnings.",
				Level = Level.Advisory,
			},
			new()
			{
				Code = "EWW",
				Name = "Extreme Wind Warning",
				Description = "This product is issued by the National Weather Service for areas on land that will experience sustained surface winds 100 knots (115 mph, 185 km/h, 51 m/s) or greater within one hour.",
				Level = Level.Warning,
			},
			new()
			{
				Code = "HWW",
				Name = "High Wind Warning",
				Description = "This product is issued by the National Weather Service when high wind speeds may pose a hazard or is life threatening. The criteria for this warning varies from state to state. In Michigan, the criteria is sustained non-convective (not related to thunderstorms) winds greater than or equal to 40 mph lasting for one hour or longer, or winds greater than or equal to 58 mph for any duration.",
				Level = Level.Warning,
			},
			new()
			{
				Code = "HWA",
				Name = "High Wind Watch",
				Description = "This product is issued by the National Weather Service when there is the potential of high wind speeds developing that may pose a hazard or is life threatening. The criteria for this watch varies from state to state. In Michigan, the criteria is the potential for sustained non-convective (not related to thunderstorms) winds greater than or equal to 40 mph and/or gusts greater than or equal to 58 mph.",
				Level = Level.Watch,
			},
			new()
			{
				Code = "SVR",
				Name = "Severe Thunderstorm Warning",
				Description = "This is issued when either a severe thunderstorm is indicated by the WSR-88D radar or a spotter reports a thunderstorm producing hail one inch or larger in diameter and/or winds equal or exceed 58 miles an hour; therefore, people in the affected area should seek safe shelter immediately. Severe thunderstorms can produce tornadoes with little or no advance warning. Lightning frequency is not a criteria for issuing a severe thunderstorm warning. They are usually issued for a duration of one hour. They can be issued without a Severe Thunderstorm Watch being already in effect.",
				Level = Level.Warning,
			},
			new()
			{
				Code = "SVA",
				Name = "Severe Thunderstorm Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of severe thunderstorms in and close to the watch area. A severe thunderstorm by definition is a thunderstorm that produces one inch hail or larger in diameter and/or winds equal or exceed 58 miles an hour. The size of the watch can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They are normally issued well in advance of the actual occurrence of severe weather. During the watch, people should review severe thunderstorm safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Level = Level.Watch,
			},
			new()
			{
				Code = "SVS",
				Name = "Severe Weather Statement",
				Description = "A National Weather Service product which provides follow up information on severe weather conditions (severe thunderstorm or tornadoes) which have occurred or are currently occurring.",
				Level = Level.Advisory,
			},
			new()
			{
				Code = "SPS",
				Name = "Special Weather Statement",
				Description = "A weather statement issued when a specified hazard is approaching advisory criteria or to highlight upcoming significant weather events. These are issued to advise of ongoing or imminent hazardous convective weather expected to continue/dissipate or expand/decrease in geographical coverage within the next one to two hours, major events forecast to occur beyond a six-hour timeframe (such as substantial temperature changes, dense fog and winter weather events), sub-severe thunderstorms (containing sustained winds or gusts of 40–57 mph (64–92 km/h) and/or hail less than one inch (2.5 cm) in diameter, in addition to frequent to continuous lightning and/or funnel clouds not expected to become a tornado threat), or to outline high-impact events supplementary to information contained in other hazardous weather products (such as black ice, short-duration heavy snow or lake-effect snow bands expected to briefly reduce visibility, heavy rainfall not expected to cause flooding, heat index or wind chill values expected to approach \"advisory\" criteria for one or two hours, or local areas of blowing dust where wind is below advisory criteria).",
				Level = Level.Advisory,
			},
			new()
			{
				Code = "TOR",
				Name = "Tornado Warning",
				Description = "This is issued when a tornado is indicated by the WSR-88D radar or sighted by spotters; therefore, people in the affected area should seek safe shelter immediately. They can be issued without a Tornado Watch being already in effect. They are usually issued for a duration of around 30 minutes.",
				Level = Level.Warning,
			},
			new()
			{
				Code = "TOA",
				Name = "Tornado Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of tornadoes in and close to the watch area. Their size can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They normally are issued well in advance of the actual occurrence of severe weather. During the watch, people should review tornado safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Level = Level.Watch,
			},
		];

		await dbContext.AlertTypes.AddRangeAsync(alertTypes);
	}
}
