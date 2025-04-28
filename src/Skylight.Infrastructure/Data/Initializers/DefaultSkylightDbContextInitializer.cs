using Skylight.Application.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Initializers;

public class DefaultSkylightDbContextInitializer(ISkylightDbContext dbContext) : ISkylightDbContextInitializer
{
	public async Task InitializeAsync()
	{
		await dbContext.ResetAsync();

		await AddAlertTypesAsync();
		await AddAlertSendersAsync();

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
				Level = AlertLevel.Warning,
			},
			new()
			{
				Code = "FFA",
				Name = "Flash Flood Watch",
				Description = "Issued to indicate current or developing hydrologic conditions that are favorable for flash flooding in and close to the watch area, but the occurrence is neither certain or imminent.",
				Level = AlertLevel.Watch,
			},
			new()
			{
				Code = "FFS",
				Name = "Flash Flood Statement",
				Description = "In hydrologic terms, a statement by the NWS which provides follow-up information on flash flood watches and warnings.",
				Level = AlertLevel.Advisory,
			},
			new()
			{
				Code = "EWW",
				Name = "Extreme Wind Warning",
				Description = "This product is issued by the National Weather Service for areas on land that will experience sustained surface winds 100 knots (115 mph, 185 km/h, 51 m/s) or greater within one hour.",
				Level = AlertLevel.Warning,
			},
			new()
			{
				Code = "HWW",
				Name = "High Wind Warning",
				Description = "This product is issued by the National Weather Service when high wind speeds may pose a hazard or is life threatening. The criteria for this warning varies from state to state. In Michigan, the criteria is sustained non-convective (not related to thunderstorms) winds greater than or equal to 40 mph lasting for one hour or longer, or winds greater than or equal to 58 mph for any duration.",
				Level = AlertLevel.Warning,
			},
			new()
			{
				Code = "HWA",
				Name = "High Wind Watch",
				Description = "This product is issued by the National Weather Service when there is the potential of high wind speeds developing that may pose a hazard or is life threatening. The criteria for this watch varies from state to state. In Michigan, the criteria is the potential for sustained non-convective (not related to thunderstorms) winds greater than or equal to 40 mph and/or gusts greater than or equal to 58 mph.",
				Level = AlertLevel.Watch,
			},
			new()
			{
				Code = "SVR",
				Name = "Severe Thunderstorm Warning",
				Description = "This is issued when either a severe thunderstorm is indicated by the WSR-88D radar or a spotter reports a thunderstorm producing hail one inch or larger in diameter and/or winds equal or exceed 58 miles an hour; therefore, people in the affected area should seek safe shelter immediately. Severe thunderstorms can produce tornadoes with little or no advance warning. Lightning frequency is not a criteria for issuing a severe thunderstorm warning. They are usually issued for a duration of one hour. They can be issued without a Severe Thunderstorm Watch being already in effect.",
				Level = AlertLevel.Warning,
			},
			new()
			{
				Code = "SVA",
				Name = "Severe Thunderstorm Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of severe thunderstorms in and close to the watch area. A severe thunderstorm by definition is a thunderstorm that produces one inch hail or larger in diameter and/or winds equal or exceed 58 miles an hour. The size of the watch can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They are normally issued well in advance of the actual occurrence of severe weather. During the watch, people should review severe thunderstorm safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Level = AlertLevel.Watch,
			},
			new()
			{
				Code = "SVS",
				Name = "Severe Weather Statement",
				Description = "A National Weather Service product which provides follow up information on severe weather conditions (severe thunderstorm or tornadoes) which have occurred or are currently occurring.",
				Level = AlertLevel.Advisory,
			},
			new()
			{
				Code = "SPS",
				Name = "Special Weather Statement",
				Description = "A weather statement issued when a specified hazard is approaching advisory criteria or to highlight upcoming significant weather events. These are issued to advise of ongoing or imminent hazardous convective weather expected to continue/dissipate or expand/decrease in geographical coverage within the next one to two hours, major events forecast to occur beyond a six-hour timeframe (such as substantial temperature changes, dense fog and winter weather events), sub-severe thunderstorms (containing sustained winds or gusts of 40–57 mph (64–92 km/h) and/or hail less than one inch (2.5 cm) in diameter, in addition to frequent to continuous lightning and/or funnel clouds not expected to become a tornado threat), or to outline high-impact events supplementary to information contained in other hazardous weather products (such as black ice, short-duration heavy snow or lake-effect snow bands expected to briefly reduce visibility, heavy rainfall not expected to cause flooding, heat index or wind chill values expected to approach \"advisory\" criteria for one or two hours, or local areas of blowing dust where wind is below advisory criteria).",
				Level = AlertLevel.Advisory,
			},
			new()
			{
				Code = "TOR",
				Name = "Tornado Warning",
				Description = "This is issued when a tornado is indicated by the WSR-88D radar or sighted by spotters; therefore, people in the affected area should seek safe shelter immediately. They can be issued without a Tornado Watch being already in effect. They are usually issued for a duration of around 30 minutes.",
				Level = AlertLevel.Warning,
			},
			new()
			{
				Code = "TOA",
				Name = "Tornado Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of tornadoes in and close to the watch area. Their size can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They normally are issued well in advance of the actual occurrence of severe weather. During the watch, people should review tornado safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Level = AlertLevel.Watch,
			},
		];

		await dbContext.AlertTypes.AddRangeAsync(alertTypes);
	}

	private async Task AddAlertSendersAsync()
	{
		AlertSender[] alertSenders =
		[
			new()
			{
				Code = "AFC",
				Name = "NWS Anchorage",
			},
			new()
			{
				Code = "AFG",
				Name = "NWS Fairbanks",
			},
			new()
			{
				Code = "AJK",
				Name = "NWS Juneau",
			},
			new()
			{
				Code = "BOU",
				Name = "NWS Denver/Boulder",
			},
			new()
			{
				Code = "GJT",
				Name = "NWS Grand Junction",
			},
			new()
			{
				Code = "PUB",
				Name = "NWS Pueblo",
			},
			new()
			{
				Code = "LOT",
				Name = "NWS Chicago",
			},
			new()
			{
				Code = "ILX",
				Name = "NWS Lincoln",
			},
			new()
			{
				Code = "IND",
				Name = "NWS Indianapolis",
			},
			new()
			{
				Code = "IWX",
				Name = "NWS Northern Indiana",
			},
			new()
			{
				Code = "DVN",
				Name = "NWS Quad Cities",
			},
			new()
			{
				Code = "DMX",
				Name = "NWS Des Moines",
			},
			new()
			{
				Code = "DDC",
				Name = "NWS Dodge City",
			},
			new()
			{
				Code = "GLD",
				Name = "NWS Goodland",
			},
			new()
			{
				Code = "TOP",
				Name = "NWS Topeka",
			},
			new()
			{
				Code = "ICT",
				Name = "NWS Wichita",
			},
			new()
			{
				Code = "JKL",
				Name = "NWS Jackson",
			},
			new()
			{
				Code = "LMK",
				Name = "NWS Louisville",
			},
			new()
			{
				Code = "PAH",
				Name = "NWS Paducah",
			},
			new()
			{
				Code = "DTX",
				Name = "NWS Detroit/Pontiac",
			},
			new()
			{
				Code = "APX",
				Name = "NWS Gaylord",
			},
			new()
			{
				Code = "GRR",
				Name = "NWS Grand Rapids",
			},
			new()
			{
				Code = "MQT",
				Name = "NWS Marquette",
			},
			new()
			{
				Code = "DLH",
				Name = "NWS Duluth",
			},
			new()
			{
				Code = "MPX",
				Name = "NWS Twin Cities",
			},
			new()
			{
				Code = "EAX",
				Name = "NWS Kansas City/Pleasant Hill",
			},
			new()
			{
				Code = "SGF",
				Name = "NWS Springfield",
			},
			new()
			{
				Code = "LSX",
				Name = "NWS St. Louis",
			},
			new()
			{
				Code = "GID",
				Name = "NWS Hastings",
			},
			new()
			{
				Code = "LBF",
				Name = "NWS North Platte",
			},
			new()
			{
				Code = "OAX",
				Name = "NWS Omaha/Valley",
			},
			new()
			{
				Code = "BIS",
				Name = "NWS Bismarc",
			},
			new()
			{
				Code = "FGF",
				Name = "NWS Grand Fork",
			},
			new()
			{
				Code = "ABR",
				Name = "NWS Aberdee",
			},
			new()
			{
				Code = "UNR",
				Name = "NWS Rapid Cit",
			},
			new()
			{
				Code = "FSD",
				Name = "NWS Sioux Fall",
			},
			new()
			{
				Code = "GRB",
				Name = "NWS Green Bay",
			},
			new()
			{
				Code = "ARX",
				Name = "NWS La Crosse",
			},
			new()
			{
				Code = "MKX",
				Name = "NWS Milwaukee/Sullivan",
			},
			new()
			{
				Code = "CYS",
				Name = "NWS Cheyenne",
			},
			new()
			{
				Code = "RIW",
				Name = "NWS Riverton",
			},
			new()
			{
				Code = "CAR",
				Name = "NWS Caribou",
			},
			new()
			{
				Code = "GYX",
				Name = "NWS Gray/Portland",
			},
			new()
			{
				Code = "BOX",
				Name = "NWS Boston/Norton",
			},
			new()
			{
				Code = "PHI",
				Name = "NWS Mount Holly/Philadelphi",
			},
			new()
			{
				Code = "ALY",
				Name = "NWS Alban",
			},
			new()
			{
				Code = "BGM",
				Name = "NWS Binghamto",
			},
			new()
			{
				Code = "BUF",
				Name = "NWS Buffal",
			},
			new()
			{
				Code = "OKX",
				Name = "NWS New Yor",
			},
			new()
			{
				Code = "MHX",
				Name = "NWS Newport/Morehead Cit",
			},
			new()
			{
				Code = "RAH",
				Name = "NWS Raleigh North",
			},
			new()
			{
				Code = "ILM",
				Name = "NWS Wilmingto",
			},
			new()
			{
				Code = "CLE",
				Name = "NWS Cleveland",
			},
			new()
			{
				Code = "ILN",
				Name = "NWS Wilmington",
			},
			new()
			{
				Code = "PBZ",
				Name = "NWS Pittsburgh",
			},
			new()
			{
				Code = "CTP",
				Name = "NWS State College",
			},
			new()
			{
				Code = "CHS",
				Name = "NWS Charlesto",
			},
			new()
			{
				Code = "CAE",
				Name = "NWS Columbi",
			},
			new()
			{
				Code = "GSP",
				Name = "NWS Greenville/Spartanbur",
			},
			new()
			{
				Code = "BTV",
				Name = "NWS Burlington",
			},
			new()
			{
				Code = "LWX",
				Name = "NWS Baltimore/Washington",
			},
			new()
			{
				Code = "RNK",
				Name = "NWS Blacksburg",
			},
			new()
			{
				Code = "AKQ",
				Name = "NWS Wakefield",
			},
			new()
			{
				Code = "RLX",
				Name = "NWS Charlesto",
			},
			new()
			{
				Code = "GUM",
				Name = "NWS Guam",
			},
			new()
			{
				Code = "HFO",
				Name = "NWS Honolulu",
			},
			new()
			{
				Code = "BMX",
				Name = "NWS Birmingham",
			},
			new()
			{
				Code = "HUN",
				Name = "NWS Huntsville",
			},
			new()
			{
				Code = "MOB",
				Name = "NWS Mobile/Pensacola",
			},
			new()
			{
				Code = "LZK",
				Name = "NWS Little Rock",
			},
			new()
			{
				Code = "JAX",
				Name = "NWS Jacksonville",
			},
			new()
			{
				Code = "KEY",
				Name = "NWS Key West",
			},
			new()
			{
				Code = "MLB",
				Name = "NWS Melbourne",
			},
			new()
			{
				Code = "MFL",
				Name = "NWS Miami",
			},
			new()
			{
				Code = "TAE",
				Name = "NWS Tallahassee",
			},
			new()
			{
				Code = "TBW",
				Name = "NWS Tampa",
			},
			new()
			{
				Code = "FFC",
				Name = "NWS Peachtree City",
			},
			new()
			{
				Code = "LCH",
				Name = "NWS Lake Charles",
			},
			new()
			{
				Code = "LIX",
				Name = "NWS New Orleans/Baton Rouge",
			},
			new()
			{
				Code = "SHV",
				Name = "NWS Shreveport",
			},
			new()
			{
				Code = "JAN",
				Name = "NWS Jackson",
			},
			new()
			{
				Code = "ABQ",
				Name = "NWS Albuquerque",
			},
			new()
			{
				Code = "OUN",
				Name = "NWS Norman",
			},
			new()
			{
				Code = "TSA",
				Name = "NWS Tulsa",
			},
			new()
			{
				Code = "SJU",
				Name = "NWS San Jua",
			},
			new()
			{
				Code = "MEG",
				Name = "NWS Memphis",
			},
			new()
			{
				Code = "MRX",
				Name = "NWS Morristown",
			},
			new()
			{
				Code = "OHX",
				Name = "NWS Nashville",
			},
			new()
			{
				Code = "AMA",
				Name = "NWS Amarillo",
			},
			new()
			{
				Code = "EWX",
				Name = "NWS Austin/San Antonio",
			},
			new()
			{
				Code = "BRO",
				Name = "NWS Brownsville",
			},
			new()
			{
				Code = "CRP",
				Name = "NWS Corpus Christi",
			},
			new()
			{
				Code = "EPZ",
				Name = "NWS El Paso",
			},
			new()
			{
				Code = "FWD",
				Name = "NWS Fort Worth/Dallas",
			},
			new()
			{
				Code = "HGX",
				Name = "NWS Houston/Galveston",
			},
			new()
			{
				Code = "LUB",
				Name = "NWS Lubbock",
			},
			new()
			{
				Code = "MAF",
				Name = "NWS Midland/Odessa",
			},
			new()
			{
				Code = "SJT",
				Name = "NWS San Angelo",
			},
			new()
			{
				Code = "FGZ",
				Name = "NWS Flagstaff",
			},
			new()
			{
				Code = "PSR",
				Name = "NWS Phoenix",
			},
			new()
			{
				Code = "TWC",
				Name = "NWS Tucson",
			},
			new()
			{
				Code = "EKA",
				Name = "NWS Eureka",
			},
			new()
			{
				Code = "LOX",
				Name = "NWS Los Angeles",
			},
			new()
			{
				Code = "STO",
				Name = "NWS Sacramento",
			},
			new()
			{
				Code = "SGX",
				Name = "NWS San Diego",
			},
			new()
			{
				Code = "MTR",
				Name = "NWS San Francisco Bay Area",
			},
			new()
			{
				Code = "HNX",
				Name = "NWS San Joaquin Valley",
			},
			new()
			{
				Code = "BOI",
				Name = "NWS Boise",
			},
			new()
			{
				Code = "PIH",
				Name = "NWS Pocatello",
			},
			new()
			{
				Code = "BYZ",
				Name = "NWS Billings",
			},
			new()
			{
				Code = "GGW",
				Name = "NWS Glasgow",
			},
			new()
			{
				Code = "TFX",
				Name = "NWS Great Falls",
			},
			new()
			{
				Code = "MSO",
				Name = "NWS Missoula",
			},
			new()
			{
				Code = "LKN",
				Name = "NWS Elko",
			},
			new()
			{
				Code = "VEF",
				Name = "NWS Las Vegas",
			},
			new()
			{
				Code = "REV",
				Name = "NWS Reno",
			},
			new()
			{
				Code = "MFR",
				Name = "NWS Medford",
			},
			new()
			{
				Code = "PDT",
				Name = "NWS Pendleton",
			},
			new()
			{
				Code = "PQR",
				Name = "NWS Portland",
			},
			new()
			{
				Code = "SLC",
				Name = "NWS Salt Lake City",
			},
			new()
			{
				Code = "SEW",
				Name = "NWS Seattle",
			},
			new()
			{
				Code = "OTX",
				Name = "NWS Spokane",
			},
		];

		await dbContext.AlertSenders.AddRangeAsync(alertSenders);
	}
}
