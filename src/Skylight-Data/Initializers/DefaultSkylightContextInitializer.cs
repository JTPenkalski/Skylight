﻿using Microsoft.AspNetCore.Identity;
using Skylight.Application.Interfaces.Data;
using Skylight.Application.UseCases.Users.Constants;
using Skylight.Domain.Constants;
using Skylight.Domain.Entities;
using Skylight.Infrastructure.Identity;

namespace Skylight.Data.Initializers;

public class DefaultSkylightContextInitializer(
	ISkylightContext dbContext,
	UserManager<User> userManager,
	RoleManager<Role> roleManager)
	: ISkylightContextInitializer
{
    public async Task InitializeAsync()
	{
		await dbContext.ResetAsync();

		await AddRolesAsync();
		await AddUsersAsync();

		await AddWeatherAlertsAsync();
		var weather = await AddWeatherAsync();
		var weatherAlertModifiers = await AddWeatherAlertModifiersAsync();
		var tags = await AddTagsAsync(weather, weatherAlertModifiers);

		await AddWeatherEventsAsync(tags);

		await dbContext.CommitAsync();
	}

	private async Task<Role[]> AddRolesAsync()
	{
		var admin = new Role { Name = Roles.Admin };

		await roleManager.CreateAsync(admin);

		return [admin];
	}

	private async Task<User[]> AddUsersAsync()
	{
		var system = new User
		{
			UserName = "Skylight",
			Email = "skylight@test.com",
			StormTracker = new()
			{
				Id = Infrastructure.Constants.SkylightSystem.Id,
				FirstName = "Skylight",
				LastName = "System",
				Biography = "The automated Skylight system.",
				StartDate = DateTimeOffset.MinValue
			}
		};

		await userManager.CreateAsync(system, "SkylightSystem");
		await userManager.AddToRoleAsync(system, Roles.Admin);

		var justin = new User
		{
			UserName = "justin@test.com",
			Email = "justin@test.com",
			StormTracker = new()
			{
				Id = Guid.Parse("b2b39e1a-df64-45e9-95ff-48b933689f39"),
				FirstName = "Justin",
				LastName = "Penkalski",
				Biography = "Test user.",
				StartDate = new DateTimeOffset(2021, 10, 31, 12, 0, 0, TimeSpan.Zero)
			}
		};

		await userManager.CreateAsync(justin, "Justin");
		await userManager.AddToRoleAsync(justin, Roles.Admin);

		var robby = new User
		{
			UserName = "robby@test.com",
			Email = "robby@test.com",
			StormTracker = new()
			{
				Id = Guid.Parse("8206e82a-7dfb-41d0-a20f-3209adffec61"),
				FirstName = "Robby",
				LastName = "LastName",
				Biography = "Biography",
				StartDate = DateTimeOffset.UtcNow
			}
		};

		await userManager.CreateAsync(robby, "Robby");
		await userManager.AddToRoleAsync(robby, Roles.Admin);

		var reed = new User
		{
			UserName = "reed@test.com",
			Email = "reed@test.com",
			StormTracker = new()
			{
				Id = Guid.Parse("472e9768-f238-49d5-8948-b1bca50e7bb9"),
				FirstName = "Reed",
				LastName = "Timmer",
				Biography = "An American meteorologist and storm chaser. Born in Grand Rapids, Michigan, he took an interest in science, including weather, at a young age, before experiencing severe weather, including a hailstorm at age 13. After presenting weather forecasts at his high school, he began studying meteorology at the University of Oklahoma, completing his PhD in 2015.",
				StartDate = new DateTimeOffset(2015, 3, 17, 19, 8, 0, TimeSpan.Zero)
			}
		};

		await userManager.CreateAsync(reed, "Reed");

		var brian = new User
		{
			UserName = "brian@test.com",
			Email = "brian@test.com",
			StormTracker = new()
			{
				Id = Guid.Parse("d4e3435b-cc80-41b1-8381-6fb16bfd4671"),
				FirstName = "Brian",
				LastName = "LastName",
				Biography = "Biography",
				StartDate = DateTimeOffset.UtcNow
			}
		};

		await userManager.CreateAsync(brian, "Brian");

		return [system, justin, robby, reed, brian];
	}

	private async Task<Weather[]> AddWeatherAsync()
	{
		var weather = new Weather[]
		{
			new()
			{
				Name = "Thunderstorm",
				Description = "A storm characterized by the presence of lightning and its acoustic effect known as thunder. Thunderstorms occur in a type of cloud known as a cumulonimbus. They are usually accompanied by strong winds and often produce heavy rain and sometimes snow, sleet, or hail, but some thunderstorms produce little precipitation or no precipitation at all.",
			},
			new()
			{
				Name = "Tornado",
				Description = "A violently rotating column of air that is in contact with both the surface of the Earth and a cumulonimbus cloud or, in rare cases, the base of a cumulus cloud with rotating debris and dust beneath it.",
			},
			new()
			{
				Name = "Hurricane",
				Description = "A rapidly rotating storm system characterized by a low-pressure center, a closed low-level atmospheric circulation, strong winds, and a spiral arrangement of thunderstorms that produce heavy rain and squalls. Depending on its location and strength, a tropical cyclone is referred to by different names, including hurricane, typhoon, tropical storm, cyclonic storm, tropical depression, or simply cyclone.",
			}
		};

		await dbContext.Weather.AddRangeAsync(weather);

		return weather;
	}

	private async Task<WeatherAlert[]> AddWeatherAlertsAsync()
	{
		const string NationalWeatherServiceSource = "National Weather Service";

		var weatherAlerts = new WeatherAlert[]
		{
			new()
			{
				Name = "Flash Flood Statement",
				Description = "In hydrologic terms, a statement by the NWS which provides follow-up information on flash flood watches and warnings.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Advisory,
				Code = "FFS",
			},
			new()
			{
				Name = "Flash Flood Warning",
				Description = "Issued to inform the public, emergency management, and other cooperating agencies that flash flooding is in progress, imminent, or highly likely.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Warning,
				Code = "FFW",
			},
			new()
			{
				Name = "Flash Flood Watch",
				Description = "Issued to indicate current or developing hydrologic conditions that are favorable for flash flooding in and close to the watch area, but the occurrence is neither certain or imminent.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Watch,
				Code = "FFA",
			},
			new()
			{
				Name = "High Wind Warning",
				Description = "This product is issued by the National Weather Service when high wind speeds may pose a hazard or is life threatening. The criteria for this warning varies from state to state. In Michigan, the criteria is sustained non-convective (not related to thunderstorms) winds greater than or equal to 40 mph lasting for one hour or longer, or winds greater than or equal to 58 mph for any duration.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Warning,
				Code = "HWA",
			},
			new()
			{
				Name = "High Wind Watch",
				Description = "This product is issued by the National Weather Service when there is the potential of high wind speeds developing that may pose a hazard or is life threatening. The criteria for this watch varies from state to state. In Michigan, the criteria is the potential for sustained non-convective (not related to thunderstorms) winds greater than or equal to 40 mph and/or gusts greater than or equal to 58 mph.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Watch,
				Code = "HWW",
			},
			new()
			{
				Name = "Severe Thunderstorm Warning",
				Description = "This is issued when either a severe thunderstorm is indicated by the WSR-88D radar or a spotter reports a thunderstorm producing hail one inch or larger in diameter and/or winds equal or exceed 58 miles an hour; therefore, people in the affected area should seek safe shelter immediately. Severe thunderstorms can produce tornadoes with little or no advance warning. Lightning frequency is not a criteria for issuing a severe thunderstorm warning. They are usually issued for a duration of one hour. They can be issued without a Severe Thunderstorm Watch being already in effect.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Warning,
				Code = "SVR",
			},
			new()
			{
				Name = "Severe Thunderstorm Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of severe thunderstorms in and close to the watch area. A severe thunderstorm by definition is a thunderstorm that produces one inch hail or larger in diameter and/or winds equal or exceed 58 miles an hour. The size of the watch can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They are normally issued well in advance of the actual occurrence of severe weather. During the watch, people should review severe thunderstorm safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Watch,
				Code = "SVA",
			},
			new()
			{
				Name = "Severe Weather Statement",
				Description = "A National Weather Service product which provides follow up information on severe weather conditions (severe thunderstorm or tornadoes) which have occurred or are currently occurring.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Advisory,
				Code = "SVS",
			},
			new()
			{
				Name = "Special Weather Statement",
				Description = "A weather statement issued when a specified hazard is approaching advisory criteria or to highlight upcoming significant weather events. These are issued to advise of ongoing or imminent hazardous convective weather expected to continue/dissipate or expand/decrease in geographical coverage within the next one to two hours, major events forecast to occur beyond a six-hour timeframe (such as substantial temperature changes, dense fog and winter weather events), sub-severe thunderstorms (containing sustained winds or gusts of 40–57 mph (64–92 km/h) and/or hail less than one inch (2.5 cm) in diameter, in addition to frequent to continuous lightning and/or funnel clouds not expected to become a tornado threat), or to outline high-impact events supplementary to information contained in other hazardous weather products (such as black ice, short-duration heavy snow or lake-effect snow bands expected to briefly reduce visibility, heavy rainfall not expected to cause flooding, heat index or wind chill values expected to approach \"advisory\" criteria for one or two hours, or local areas of blowing dust where wind is below advisory criteria).",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Advisory,
				Code = "SPS",
			},
			new()
			{
				Name = "Tornado Warning",
				Description = "This is issued when a tornado is indicated by the WSR-88D radar or sighted by spotters; therefore, people in the affected area should seek safe shelter immediately. They can be issued without a Tornado Watch being already in effect. They are usually issued for a duration of around 30 minutes.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Warning,
				Code = "TOR",
			},
			new()
			{
				Name = "Tornado Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of tornadoes in and close to the watch area. Their size can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They normally are issued well in advance of the actual occurrence of severe weather. During the watch, people should review tornado safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Watch,
				Code = "TOA",
			},
			new()
			{
				Name = "Wind Advisory",
				Description = "Sustained winds 25 to 39 mph and/or gusts to 57 mph. Issuance is normally site specific. However, winds of this magnitude occurring over an area that frequently experiences such winds.",
				Source = NationalWeatherServiceSource,
				Level = WeatherAlertLevel.Advisory,
			},
		};

		await dbContext.WeatherAlerts.AddRangeAsync(weatherAlerts);

		return weatherAlerts;
	}

	private async Task<WeatherAlertModifier[]> AddWeatherAlertModifiersAsync()
	{
		var weatherAlertModifiers = new WeatherAlertModifier[]
		{
			new()
			{
				Name = "Radar Indicated",
				Description = "Used when a potential tornado was spotted on the radar, indicated by rotation, debris, or otherwise.",
				Bonus = 0,
				Operation = WeatherAlertModifierOperation.Add,
			},
			new()
			{
				Name = "Observed",
				Description = "Used when a live tornado was witnessed by the public, storm chasers, emergency management or law enforcement.",
				Bonus = 2,
				Operation = WeatherAlertModifierOperation.Add,
			},
			new()
			{
				Name = "Considerable",
				Description = "Used for Severe Thunderstorm Warnings when hail of 1.75 inches or larger and/or winds at or above 70 miles per hour is indicated by radar or observed.",
				Bonus = 3,
				Operation = WeatherAlertModifierOperation.Add,
			},
			new()
			{
				Name = "Destructive",
				Description = "Used for Severe Thunderstorm Warnings when hail of 2.75 inches or larger and/or winds at or above 80 miles per hour is indicated by radar or observed.",
				Bonus = 5,
				Operation = WeatherAlertModifierOperation.Add,
			},
			new()
			{
				Name = "PDS",
				Description = "Used when a Watch or Warning is a Particularly Dangerous Situation. It is used to convey special urgency for unusually extreme and life-threatening severe weather events, above and beyond the average severity for the type of event.",
				Bonus = 5,
				Operation = WeatherAlertModifierOperation.Add,
			},
			new()
			{
				Name = "Emergency",
				Description = "Used for the highest level Tornado Warnings. It generally means that significant, widespread damage is expected to occur and a high likelihood of numerous fatalities is expected with a large, strong to violent tornado.",
				Bonus = 7,
				Operation = WeatherAlertModifierOperation.Add,
			},
		};

		await dbContext.WeatherAlertModifiers.AddRangeAsync(weatherAlertModifiers);

		return weatherAlertModifiers;
	}

	private async Task<Tag[]> AddTagsAsync(Weather[] weather, WeatherAlertModifier[] weatherAlertModifiers)
	{
		var weatherTags = weather
			.Select(x => new Tag
			{
				Name = x.Name,
				Description = x.Description
			});

		var weatherAlertModifierTags = weatherAlertModifiers
			.Select(x => new Tag
			{
				Name = x.Name,
				Description = x.Description
			});

		var tags = new Tag[]
		{
			new()
			{
				Name = "Outbreak",
				Description = "Used when a Weather Event produces multiple tornadoes spawned by the same synoptic scale weather system. The number of tornadoes required to qualify as an outbreak typically are at least six to ten, with at least two rotational locations (if squall line) or at least two supercells producing multiple tornadoes."
			},
			new()
			{
				Name = "Nocturnal",
				Description = "Used when a Weather Event produced significant activity during the nighttime. Nocturnal tornadoes are nearly 2 times as deadly as daytime events, and the number of of overnight tornadoes has been increasing in recent years."
			},
		};

		await dbContext.Tags.AddRangeAsync(weatherTags);
		await dbContext.Tags.AddRangeAsync(weatherAlertModifierTags);
		await dbContext.Tags.AddRangeAsync(tags);

		return [.. weatherTags, .. weatherAlertModifierTags, .. tags];
	}

	private async Task<WeatherEvent[]> AddWeatherEventsAsync(Tag[] tags)
	{
		var weatherEvents = new WeatherEvent[]
		{
			new()
			{
				Id = Guid.Parse("8513237d-1a5a-45bd-9d63-1b83d633ea11"),
				Name = "Tornado Outbreak of April 26-28, 2024",
				Description = "From April 26-28, 2024, a very large, deadly and destructive tornado outbreak occurred across the Midwestern, Southern, and High Plains regions of the United States, primarily on April 26 and 27. The Storm Prediction Center (SPC) first issued an enhanced risk for the Plains on April 26, as a broad upper-trough moved eastwards, with tornadic activity erupted in the states of Iowa and Kansas that evening. A moderate risk was issued by the SPC on April 27 for areas further south in Oklahoma, where a deadly nocturnal event unfolded with many supercell thunderstorms and tornadoes tracking over towns several times. Millions were put under a particularly dangerous situation (PDS) tornado watch on April 27, and several PDS tornado warnings were issued that night as numerous strong tornadoes touched down. The outbreak served as the beginning of a broader 16-day period of constant severe weather and tornado activity across the United States that would continue until May 10.",
				StartDate = new DateTimeOffset(2024, 4, 26, 20, 0, 0, TimeSpan.Zero),
				EndDate = new DateTimeOffset(2024, 4, 28, 10, 0, 0, TimeSpan.Zero),
				DamageCost = 1_800_000_000,
				AffectedPeople = 8
			},
			new()
			{
				Id = Guid.Parse("92d65b0d-250c-410e-b50e-b1a501a13d0f"),
				Name = "Tornado Outbreak of May 19-26, 2024",
				Description = "A multi-day period of significant tornado activity is currently unfolding across the Midwestern United States and the Mississippi Valley. Tornadoes have been reported across large portions of the Central United States, including several strong tornadoes. Multiple Particularly Dangerous Situation (PDS) watches were issued across the sequence, including Severe Thunderstorm Watch 260 on the 19th,[8] Tornado Watch 277 on the 21st, Tornado Watch 308 on the 25th, and Tornado Watch 320 on the 26th. Five fatalities have been confirmed with a large, violent EF4 tornado that went through Greenfield, Iowa on the 21st. Tornadic activity continued over the next several days, including a nocturnal outbreak that occurred during the overnight hours of May 25 into May 26. Seven fatalities were confirmed from a destructive tornado that struck Valley View, Texas while two more fatalities were confirmed from an EF3+ tornado that struck Claremore and Pryor, Oklahoma. Another fatality was confirmed from a tornado in Olvey, Arkansas and an additional tornadic death also occurred in Arkansas. Many other tornadoes occurred on the afternoon and evening of the 26th, including a very destructive, intense tornado, which prompted the issuance of 4 tornado emergencies across western Kentucky.",
				StartDate = new DateTimeOffset(2024, 4, 26, 20, 0, 0, TimeSpan.Zero),
				EndDate = null,
				DamageCost = null,
				AffectedPeople = 117,
			}
		};

		foreach (WeatherEvent weatherEvent in weatherEvents)
		{
			var participant1 = new WeatherEventParticipant
			{
				Event = weatherEvent,
				Tracker = await dbContext.FindAsync<StormTracker>(Guid.Parse("8206e82a-7dfb-41d0-a20f-3209adffec61"), CancellationToken.None),
				ParticipationMethod = ParticipationMethod.Chased
			};

			weatherEvent.AddParticipant(participant1);

			var participant2 = new WeatherEventParticipant
			{
				Event = weatherEvent,
				Tracker = await dbContext.FindAsync<StormTracker>(Guid.Parse("d4e3435b-cc80-41b1-8381-6fb16bfd4671"), CancellationToken.None),
				ParticipationMethod = ParticipationMethod.Viewed
			};

			weatherEvent.AddParticipant(participant2);

			weatherEvent.AddTag(new WeatherEventTag
			{
				Event = weatherEvent,
				Tag = tags.Single(x => x.Name == "Tornado"),
				Votes = 5,
			});
			weatherEvent.AddTag(new WeatherEventTag
			{
				Event = weatherEvent,
				Tag = tags.Single(x => x.Name == "Thunderstorm"),
				Votes = 5,
			});
			weatherEvent.AddTag(new WeatherEventTag
			{
				Event = weatherEvent,
				Tag = tags.Single(x => x.Name == "Outbreak"),
				Votes = 5,
			});
			weatherEvent.AddTag(new WeatherEventTag
			{
				Event = weatherEvent,
				Tag = tags.Single(x => x.Name == "Nocturnal"),
				Votes = 5,
			});
			weatherEvent.AddTag(new WeatherEventTag
			{
				Event = weatherEvent,
				Tag = tags.Single(x => x.Name == "PDS"),
				Votes = 5,
			});

			weatherEvent.ClearEvents();
		}

		await dbContext.WeatherEvents.AddRangeAsync(weatherEvents);

		return weatherEvents;
	}
}
