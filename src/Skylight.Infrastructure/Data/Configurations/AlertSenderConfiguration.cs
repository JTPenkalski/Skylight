using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Application.Common.Identity;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertSenderConfiguration : BaseAuditableEntityConfiguration<AlertSender>
{
	public override void Configure(EntityTypeBuilder<AlertSender> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.Code);

		builder
			.Property(x => x.Code)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.HasData(GetSeed());
	}

	private static AlertSender[] GetSeed()
	{
		AlertSender[] alertSenders =
		[
			new()
			{
				Code = "AFC",
				Name = "NWS Anchorage",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "AFG",
				Name = "NWS Fairbanks",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "AJK",
				Name = "NWS Juneau",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BOU",
				Name = "NWS Denver/Boulder",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GJT",
				Name = "NWS Grand Junction",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PUB",
				Name = "NWS Pueblo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LOT",
				Name = "NWS Chicago",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ILX",
				Name = "NWS Lincoln",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "IND",
				Name = "NWS Indianapolis",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "IWX",
				Name = "NWS Northern Indiana",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "DVN",
				Name = "NWS Quad Cities",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "DMX",
				Name = "NWS Des Moines",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "DDC",
				Name = "NWS Dodge City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GLD",
				Name = "NWS Goodland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "TOP",
				Name = "NWS Topeka",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ICT",
				Name = "NWS Wichita",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "JKL",
				Name = "NWS Jackson",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LMK",
				Name = "NWS Louisville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PAH",
				Name = "NWS Paducah",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "DTX",
				Name = "NWS Detroit/Pontiac",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "APX",
				Name = "NWS Gaylord",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GRR",
				Name = "NWS Grand Rapids",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MQT",
				Name = "NWS Marquette",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "DLH",
				Name = "NWS Duluth",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MPX",
				Name = "NWS Twin Cities",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "EAX",
				Name = "NWS Kansas City/Pleasant Hill",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SGF",
				Name = "NWS Springfield",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LSX",
				Name = "NWS St. Louis",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GID",
				Name = "NWS Hastings",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LBF",
				Name = "NWS North Platte",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "OAX",
				Name = "NWS Omaha/Valley",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BIS",
				Name = "NWS Bismarck",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "FGF",
				Name = "NWS Grand Fork",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ABR",
				Name = "NWS Aberdee",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "UNR",
				Name = "NWS Rapid City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "FSD",
				Name = "NWS Sioux Fall",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GRB",
				Name = "NWS Green Bay",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ARX",
				Name = "NWS La Crosse",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MKX",
				Name = "NWS Milwaukee/Sullivan",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CYS",
				Name = "NWS Cheyenne",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "RIW",
				Name = "NWS Riverton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CAR",
				Name = "NWS Caribou",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GYX",
				Name = "NWS Gray/Portland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BOX",
				Name = "NWS Boston/Norton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PHI",
				Name = "NWS Mount Holly/Philadelphia",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ALY",
				Name = "NWS Albany",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BGM",
				Name = "NWS Binghamton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BUF",
				Name = "NWS Buffalo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "OKX",
				Name = "NWS New York",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MHX",
				Name = "NWS Newport/Morehead City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "RAH",
				Name = "NWS Raleigh North",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ILM",
				Name = "NWS Wilmington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CLE",
				Name = "NWS Cleveland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ILN",
				Name = "NWS Wilmington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PBZ",
				Name = "NWS Pittsburgh",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CTP",
				Name = "NWS State College",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CHS",
				Name = "NWS Charlesto",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CAE",
				Name = "NWS Columbia",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GSP",
				Name = "NWS Greenville/Spartanburg",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BTV",
				Name = "NWS Burlington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LWX",
				Name = "NWS Baltimore/Washington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "RNK",
				Name = "NWS Blacksburg",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "AKQ",
				Name = "NWS Wakefield",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "RLX",
				Name = "NWS Charlesto",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GUM",
				Name = "NWS Guam",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "HFO",
				Name = "NWS Honolulu",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BMX",
				Name = "NWS Birmingham",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "HUN",
				Name = "NWS Huntsville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MOB",
				Name = "NWS Mobile/Pensacola",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LZK",
				Name = "NWS Little Rock",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "JAX",
				Name = "NWS Jacksonville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "KEY",
				Name = "NWS Key West",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MLB",
				Name = "NWS Melbourne",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MFL",
				Name = "NWS Miami",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "TAE",
				Name = "NWS Tallahassee",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "TBW",
				Name = "NWS Tampa",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "FFC",
				Name = "NWS Peachtree City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LCH",
				Name = "NWS Lake Charles",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LIX",
				Name = "NWS New Orleans/Baton Rouge",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SHV",
				Name = "NWS Shreveport",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "JAN",
				Name = "NWS Jackson",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "ABQ",
				Name = "NWS Albuquerque",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "OUN",
				Name = "NWS Norman",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "TSA",
				Name = "NWS Tulsa",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SJU",
				Name = "NWS San Jua",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MEG",
				Name = "NWS Memphis",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MRX",
				Name = "NWS Morristown",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "OHX",
				Name = "NWS Nashville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "AMA",
				Name = "NWS Amarillo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "EWX",
				Name = "NWS Austin/San Antonio",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BRO",
				Name = "NWS Brownsville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "CRP",
				Name = "NWS Corpus Christi",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "EPZ",
				Name = "NWS El Paso",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "FWD",
				Name = "NWS Fort Worth/Dallas",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "HGX",
				Name = "NWS Houston/Galveston",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LUB",
				Name = "NWS Lubbock",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MAF",
				Name = "NWS Midland/Odessa",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SJT",
				Name = "NWS San Angelo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "FGZ",
				Name = "NWS Flagstaff",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PSR",
				Name = "NWS Phoenix",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "TWC",
				Name = "NWS Tucson",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "EKA",
				Name = "NWS Eureka",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LOX",
				Name = "NWS Los Angeles",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "STO",
				Name = "NWS Sacramento",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SGX",
				Name = "NWS San Diego",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MTR",
				Name = "NWS San Francisco Bay Area",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "HNX",
				Name = "NWS San Joaquin Valley",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BOI",
				Name = "NWS Boise",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PIH",
				Name = "NWS Pocatello",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "BYZ",
				Name = "NWS Billings",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "GGW",
				Name = "NWS Glasgow",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "TFX",
				Name = "NWS Great Falls",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MSO",
				Name = "NWS Missoula",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "LKN",
				Name = "NWS Elko",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "VEF",
				Name = "NWS Las Vegas",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "REV",
				Name = "NWS Reno",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "MFR",
				Name = "NWS Medford",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PDT",
				Name = "NWS Pendleton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "PQR",
				Name = "NWS Portland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SLC",
				Name = "NWS Salt Lake City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "SEW",
				Name = "NWS Seattle",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Code = "OTX",
				Name = "NWS Spokane",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
		];

		return alertSenders;
	}
}
