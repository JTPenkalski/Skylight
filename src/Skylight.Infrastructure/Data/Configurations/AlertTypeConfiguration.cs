using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Application.Common.Identity;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertTypeConfiguration : BaseAuditableEntityConfiguration<AlertType>
{
	public override void Configure(EntityTypeBuilder<AlertType> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.ProductCode);

		builder
			.HasIndex(x => x.EventCode);

		builder
			.HasIndex(x => new { x.ProductCode, x.EventCode })
			.IsUnique();

		builder
			.Property(x => x.ProductCode)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.EventCode)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(x => x.Description)
			.HasMaxLength(DatabaseConfigurations.MaxLengthLong);

		builder
			.Property(x => x.TypeCode)
			.HasComputedColumnSql(@$"COALESCE(""{nameof(AlertType.EventCode)}"", ""{nameof(AlertType.ProductCode)}"")", stored: true);

		builder
			.HasData(GetSeed());
	}

	private static AlertType[] GetSeed()
	{
		AlertType[] alertTypes =
		[
			new()
			{
				Id = Guid.Parse("c8a66177-6201-4d9b-b007-f66a7cc090a3"),
				ProductCode = "SVS",
				Name = "Severe Weather Statement",
				Description = "A National Weather Service product which provides follow up information on severe weather conditions (severe thunderstorm or tornadoes) which have occurred or are currently occurring.",
				Level = AlertLevel.Advisory,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4a4461ce-2b48-4dfb-938b-e40a8ce35437"),
				ProductCode = "SPS",
				Name = "Special Weather Statement",
				Description = "A weather statement issued when a specified hazard is approaching advisory criteria or to highlight upcoming significant weather events. These are issued to advise of ongoing or imminent hazardous convective weather expected to continue/dissipate or expand/decrease in geographical coverage within the next one to two hours, major events forecast to occur beyond a six-hour timeframe (such as substantial temperature changes, dense fog and winter weather events), sub-severe thunderstorms (containing sustained winds or gusts of 40–57 mph (64–92 km/h) and/or hail less than one inch (2.5 cm) in diameter, in addition to frequent to continuous lightning and/or funnel clouds not expected to become a tornado threat), or to outline high-impact events supplementary to information contained in other hazardous weather products (such as black ice, short-duration heavy snow or lake-effect snow bands expected to briefly reduce visibility, heavy rainfall not expected to cause flooding, heat index or wind chill values expected to approach \"advisory\" criteria for one or two hours, or local areas of blowing dust where wind is below advisory criteria).",
				Level = AlertLevel.Advisory,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("43f44630-21db-4421-871d-f2d327489552"),
				ProductCode = "FFW",
				EventCode = "FFW",
				Name = "Flash Flood Warning",
				Description = "Issued to inform the public, emergency management, and other cooperating agencies that flash flooding is in progress, imminent, or highly likely.",
				Level = AlertLevel.Warning,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a312351a-fb7b-40bd-9e9d-685d0840ed01"),
				ProductCode = "FFA",
				EventCode = "FFA",
				Name = "Flash Flood Watch",
				Description = "Issued to indicate current or developing hydrologic conditions that are favorable for flash flooding in and close to the watch area, but the occurrence is neither certain or imminent.",
				Level = AlertLevel.Watch,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5434ef57-6bd0-4dda-8e72-bde8fc4bb7d5"),
				ProductCode = "FFS",
				EventCode = "FFS",
				Name = "Flash Flood Statement",
				Description = "In hydrologic terms, a statement by the NWS which provides follow-up information on flash flood watches and warnings.",
				Level = AlertLevel.Advisory,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a349126f-92f1-4222-a3cf-bd105b7764f5"),
				ProductCode = "SVR",
				EventCode = "SVW",
				Name = "Severe Thunderstorm Warning",
				Description = "This is issued when either a severe thunderstorm is indicated by the WSR-88D radar or a spotter reports a thunderstorm producing hail one inch or larger in diameter and/or winds equal or exceed 58 miles an hour; therefore, people in the affected area should seek safe shelter immediately. Severe thunderstorms can produce tornadoes with little or no advance warning. Lightning frequency is not a criteria for issuing a severe thunderstorm warning. They are usually issued for a duration of one hour. They can be issued without a Severe Thunderstorm Watch being already in effect.",
				Level = AlertLevel.Warning,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5e82b31c-c3f7-4911-8d54-2944d6782ba8"),
				ProductCode = "TOR",
				EventCode = "TOW",
				Name = "Tornado Warning",
				Description = "This is issued when a tornado is indicated by the WSR-88D radar or sighted by spotters; therefore, people in the affected area should seek safe shelter immediately. They can be issued without a Tornado Watch being already in effect. They are usually issued for a duration of around 30 minutes.",
				Level = AlertLevel.Warning,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("be8f23f2-23b1-4f6a-9919-e48d854cb243"),
				ProductCode = "WOU",
				EventCode = "SVA",
				Name = "Severe Thunderstorm Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of severe thunderstorms in and close to the watch area. A severe thunderstorm by definition is a thunderstorm that produces one inch hail or larger in diameter and/or winds equal or exceed 58 miles an hour. The size of the watch can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They are normally issued well in advance of the actual occurrence of severe weather. During the watch, people should review severe thunderstorm safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Level = AlertLevel.Watch,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4a4f23be-9135-4bcb-bb19-7f39a8a8a25d"),
				ProductCode = "WOU",
				EventCode = "TOA",
				Name = "Tornado Watch",
				Description = "This is issued by the National Weather Service when conditions are favorable for the development of tornadoes in and close to the watch area. Their size can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They normally are issued well in advance of the actual occurrence of severe weather. During the watch, people should review tornado safety rules and be prepared to move a place of safety if threatening weather approaches.",
				Level = AlertLevel.Watch,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
		];

		return alertTypes;
	}
}
