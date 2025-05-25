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
				Id = Guid.Parse("52c35b4a-653b-46f1-bd82-0e474c75893f"),
				Code = "AFC",
				Name = "NWS Anchorage",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e86bf576-78fb-4065-ab44-e934b7959e4a"),
				Code = "AFG",
				Name = "NWS Fairbanks",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ff7f49da-b154-4fd5-980d-1790046c4c58"),
				Code = "AJK",
				Name = "NWS Juneau",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ec13a114-e78e-4c65-9d00-bb5140d36329"),
				Code = "BOU",
				Name = "NWS Denver/Boulder",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("8a2c6cb5-82ce-4e17-a778-e4adfaef7056"),
				Code = "GJT",
				Name = "NWS Grand Junction",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b08b0b49-fb75-46a5-8d0a-a60240a79e3a"),
				Code = "PUB",
				Name = "NWS Pueblo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5a3bbe70-5f16-4290-959c-ec8813a2ae82"),
				Code = "LOT",
				Name = "NWS Chicago",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("59a6c9a8-95db-4d8a-8038-02962e10fe14"),
				Code = "ILX",
				Name = "NWS Lincoln",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("dfc086c9-3a68-4368-b77a-c69f7f018aa9"),
				Code = "IND",
				Name = "NWS Indianapolis",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("8cd29888-8dc8-40e9-bf97-76bb3761ed80"),
				Code = "IWX",
				Name = "NWS Northern Indiana",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("fc8e9ba3-ddd1-4fa9-9656-5e85e846a534"),
				Code = "DVN",
				Name = "NWS Quad Cities",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ada98b38-ea71-49a6-9066-86c6e94e0ae9"),
				Code = "DMX",
				Name = "NWS Des Moines",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("7db25e25-a0d7-4237-8163-d732a2366fbc"),
				Code = "DDC",
				Name = "NWS Dodge City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("6d80e8f5-d7fe-45dc-91f2-70ef33d69c02"),
				Code = "GLD",
				Name = "NWS Goodland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("001382ad-4143-4075-960b-e25939d38c14"),
				Code = "TOP",
				Name = "NWS Topeka",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("6ba0bf0b-cdb6-456f-9d71-66bdc8128ea2"),
				Code = "ICT",
				Name = "NWS Wichita",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("1833e572-775d-42e8-a10d-894947ba4c72"),
				Code = "JKL",
				Name = "NWS Jackson",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4350f374-9061-4c6f-bf5c-2bae508b8129"),
				Code = "LMK",
				Name = "NWS Louisville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("65877500-3987-49bc-9db8-e71265d742be"),
				Code = "PAH",
				Name = "NWS Paducah",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b99be2df-a3df-4dc2-8509-565626817412"),
				Code = "DTX",
				Name = "NWS Detroit/Pontiac",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b513fcfc-40ff-480c-a73a-9c4a6823d729"),
				Code = "APX",
				Name = "NWS Gaylord",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5fcf256c-d0ca-4533-b7e2-e8cce2514c47"),
				Code = "GRR",
				Name = "NWS Grand Rapids",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("7216a99c-49b2-446c-971f-849ea0642b10"),
				Code = "MQT",
				Name = "NWS Marquette",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("70cf1e8a-1cec-4a3b-8e65-939ecb780622"),
				Code = "DLH",
				Name = "NWS Duluth",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("8f63fbe1-3e28-4fdd-983b-0a2844bcc59b"),
				Code = "MPX",
				Name = "NWS Twin Cities",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e23cb76a-757a-4317-a8e6-9dcd9efdfcf5"),
				Code = "EAX",
				Name = "NWS Kansas City/Pleasant Hill",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("2f714d64-8bcc-4b56-ab34-fadddece36f7"),
				Code = "SGF",
				Name = "NWS Springfield",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4b2169a9-c48c-4372-8a98-693f4e7ca190"),
				Code = "LSX",
				Name = "NWS St. Louis",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("aff2166a-dc65-4dbb-b112-06f84b30cc50"),
				Code = "GID",
				Name = "NWS Hastings",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("38feda61-88ca-4d20-90b1-06e65e9e7f11"),
				Code = "LBF",
				Name = "NWS North Platte",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("fa675f2a-f105-48f2-8219-4beb767d1ec4"),
				Code = "OAX",
				Name = "NWS Omaha/Valley",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("06f137a5-aa58-4151-ad4d-999bde3965fd"),
				Code = "BIS",
				Name = "NWS Bismarck",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("cde34b64-e24c-4af9-ba4e-56c371b2ff12"),
				Code = "FGF",
				Name = "NWS Grand Fork",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a60b1be3-122e-429d-a31c-4b22e29b8f9f"),
				Code = "ABR",
				Name = "NWS Aberdee",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("20e3a576-f20b-4c93-9558-4bfe90fe1503"),
				Code = "UNR",
				Name = "NWS Rapid City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("12f93626-4d50-408e-91a3-b6cdf406ef2d"),
				Code = "FSD",
				Name = "NWS Sioux Fall",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("d55e1e3c-aae1-49df-ab3d-90406e37bd12"),
				Code = "GRB",
				Name = "NWS Green Bay",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5acdae5e-4b49-4053-bf43-2b0083512882"),
				Code = "ARX",
				Name = "NWS La Crosse",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a0af1fea-d647-42cd-b5b8-f55b89009ef2"),
				Code = "MKX",
				Name = "NWS Milwaukee/Sullivan",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("c3c91064-75c3-44e1-91c5-feb79f6e819c"),
				Code = "CYS",
				Name = "NWS Cheyenne",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e0a630eb-4707-4738-9a90-d901aab30d54"),
				Code = "RIW",
				Name = "NWS Riverton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("d8bd481c-d915-4bba-bc88-a7cf70ce4e4e"),
				Code = "CAR",
				Name = "NWS Caribou",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("bc6c324b-5cd8-4f54-907e-d0845f11444d"),
				Code = "GYX",
				Name = "NWS Gray/Portland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4385ba25-5a19-4928-9433-37df725f4752"),
				Code = "BOX",
				Name = "NWS Boston/Norton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("8fd8f311-3dc2-427e-8182-dfc45549cee0"),
				Code = "PHI",
				Name = "NWS Mount Holly/Philadelphia",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ec9c708a-f0a2-4fb8-a9fb-77dafc6483d4"),
				Code = "ALY",
				Name = "NWS Albany",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ac3ac668-301c-4e9c-89e6-f0b2fcf5de56"),
				Code = "BGM",
				Name = "NWS Binghamton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("306fb3e4-897a-4ef5-bcf7-607232c4a897"),
				Code = "BUF",
				Name = "NWS Buffalo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e13cde99-0296-4832-8c5f-e7ae4115d26c"),
				Code = "OKX",
				Name = "NWS New York",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("8505dace-9d60-431c-a7ef-278ce6ffc5b6"),
				Code = "MHX",
				Name = "NWS Newport/Morehead City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("043d5214-8653-4ea4-a7c9-cdc8487d1ccb"),
				Code = "RAH",
				Name = "NWS Raleigh North",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("1dd67163-cb82-4f18-9a7e-399728669a78"),
				Code = "ILM",
				Name = "NWS Wilmington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("f34dc1bd-fe8d-4f39-98f6-25977a0b0800"),
				Code = "CLE",
				Name = "NWS Cleveland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("da48fcf2-9a36-4cdc-abab-c1734a650ac2"),
				Code = "ILN",
				Name = "NWS Wilmington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("d0386bc4-d1e6-4ab9-a525-3f97a8fda648"),
				Code = "PBZ",
				Name = "NWS Pittsburgh",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("d9ec8bb2-7859-488b-82d0-c7cccee874e5"),
				Code = "CTP",
				Name = "NWS State College",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b3a78ffd-37a2-4663-928f-81feb479d205"),
				Code = "CHS",
				Name = "NWS Charlesto",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e34917c4-1212-4e08-8299-e3a5896fc982"),
				Code = "CAE",
				Name = "NWS Columbia",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("377c698f-fe43-48cb-9df6-52af611cb08c"),
				Code = "GSP",
				Name = "NWS Greenville/Spartanburg",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e4172543-8af7-49c5-9c6a-bb0074c47870"),
				Code = "BTV",
				Name = "NWS Burlington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("37cf2a4a-9c9c-4c01-96a3-3ac4f392505f"),
				Code = "LWX",
				Name = "NWS Baltimore/Washington",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("847700b4-2040-4669-8904-73f85be84b88"),
				Code = "RNK",
				Name = "NWS Blacksburg",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("eac912a6-595b-4166-b816-660bfcedeffa"),
				Code = "AKQ",
				Name = "NWS Wakefield",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("145c5051-c688-4487-a803-e83f4fcabc1e"),
				Code = "RLX",
				Name = "NWS Charlesto",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("9318342e-964e-4af4-98c7-98f459d012d1"),
				Code = "GUM",
				Name = "NWS Guam",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4d99506c-6023-4708-b48c-06f8e534d6ba"),
				Code = "HFO",
				Name = "NWS Honolulu",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a8578756-e0c0-4b44-86bf-b54d20181964"),
				Code = "BMX",
				Name = "NWS Birmingham",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("c1248289-4f30-49dd-8988-c24e05d6bcd3"),
				Code = "HUN",
				Name = "NWS Huntsville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("9081c006-67ad-486c-b9b6-d75d961ea004"),
				Code = "MOB",
				Name = "NWS Mobile/Pensacola",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5f85bc59-5a63-4052-b8bc-592193317846"),
				Code = "LZK",
				Name = "NWS Little Rock",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("f468413b-b9d3-4590-aeb3-fea78abbec2f"),
				Code = "JAX",
				Name = "NWS Jacksonville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("9678f207-df1b-428e-8397-a184f3a0ee48"),
				Code = "KEY",
				Name = "NWS Key West",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("19c76882-fb3d-488a-8e9d-a7dd67bb3940"),
				Code = "MLB",
				Name = "NWS Melbourne",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b03efd4a-a90d-4514-9eff-a011ac77d256"),
				Code = "MFL",
				Name = "NWS Miami",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("3b567347-e762-4598-a750-e9f58ae4903c"),
				Code = "TAE",
				Name = "NWS Tallahassee",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("12f9c72d-97ce-4e82-aeb5-7a7ae999a6c8"),
				Code = "TBW",
				Name = "NWS Tampa",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("bb03d5e5-a868-485e-aa14-c6c157d95036"),
				Code = "FFC",
				Name = "NWS Peachtree City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4fd91921-a691-4684-824a-8dcdde63bca9"),
				Code = "LCH",
				Name = "NWS Lake Charles",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ca12e950-6b48-4f5d-b992-b386a800d009"),
				Code = "LIX",
				Name = "NWS New Orleans/Baton Rouge",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ead8d492-74f8-46ed-a590-223329debeca"),
				Code = "SHV",
				Name = "NWS Shreveport",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b9984c93-c83a-4574-baa3-39951034b4ba"),
				Code = "JAN",
				Name = "NWS Jackson",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("f04e98af-86f7-4535-babf-6e729ff84275"),
				Code = "ABQ",
				Name = "NWS Albuquerque",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("cc5c48f4-196e-4673-92ed-45d62bf61d0b"),
				Code = "OUN",
				Name = "NWS Norman",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("17b93477-b647-420b-bcc0-75eefb6734d1"),
				Code = "TSA",
				Name = "NWS Tulsa",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e8e52f2a-a403-4cc1-a550-c651dcb607c3"),
				Code = "SJU",
				Name = "NWS San Jua",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("b886c96b-c07d-4dbc-afe6-ce4dc1e22b33"),
				Code = "MEG",
				Name = "NWS Memphis",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("63bacad6-0460-4ef9-bad5-7214ba9b5fe7"),
				Code = "MRX",
				Name = "NWS Morristown",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("3d595d50-0216-456b-b95e-416ad2c7771e"),
				Code = "OHX",
				Name = "NWS Nashville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("1c9e022b-975f-411f-b890-bad1ba9a7cca"),
				Code = "AMA",
				Name = "NWS Amarillo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("468481f8-7ac3-4d62-9873-e086d1c349c5"),
				Code = "EWX",
				Name = "NWS Austin/San Antonio",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("fe44cb6c-65d3-48cb-9ae8-7f3e5735d871"),
				Code = "BRO",
				Name = "NWS Brownsville",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("82899735-8877-4c12-b8a0-e679cbe1582a"),
				Code = "CRP",
				Name = "NWS Corpus Christi",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("11035a3c-5bea-46e4-bea5-a1733fe59b53"),
				Code = "EPZ",
				Name = "NWS El Paso",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5a8ca515-8cf2-4213-a974-fb1317e7e649"),
				Code = "FWD",
				Name = "NWS Fort Worth/Dallas",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4e4e6437-65d6-4505-b7b7-005d99cf182e"),
				Code = "HGX",
				Name = "NWS Houston/Galveston",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("97969901-52ca-437d-a226-770dfc538f50"),
				Code = "LUB",
				Name = "NWS Lubbock",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("db1a00b0-3412-4fa7-b0b4-30bbbcda7a2d"),
				Code = "MAF",
				Name = "NWS Midland/Odessa",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("879c0b7e-24ce-4deb-abda-51a2ee90b6c0"),
				Code = "SJT",
				Name = "NWS San Angelo",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("36600f01-c7cf-4d9c-a14d-898f48dafe4c"),
				Code = "FGZ",
				Name = "NWS Flagstaff",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("668d6067-e7c9-47fc-8269-c9c6a4cbf1aa"),
				Code = "PSR",
				Name = "NWS Phoenix",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("3459fab2-416c-4ead-a5a1-c363bcc37806"),
				Code = "TWC",
				Name = "NWS Tucson",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("38e3c394-1b3e-479e-8400-3dbb76fddd7f"),
				Code = "EKA",
				Name = "NWS Eureka",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("9871fad4-16b2-4c66-8e57-45e98644dbb4"),
				Code = "LOX",
				Name = "NWS Los Angeles",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("dc47825b-4ebc-4afc-9cc3-91593ce3beee"),
				Code = "STO",
				Name = "NWS Sacramento",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("bf6ebce9-528b-407f-a9cb-0a19db00ff81"),
				Code = "SGX",
				Name = "NWS San Diego",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("0c1785b4-e0ee-41cf-9862-340dd2a5f7ff"),
				Code = "MTR",
				Name = "NWS San Francisco Bay Area",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("53ab0911-8a41-4a93-bd2d-93220f9cf4dd"),
				Code = "HNX",
				Name = "NWS San Joaquin Valley",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("f04af92c-8c67-4a49-859f-79252c135a7b"),
				Code = "BOI",
				Name = "NWS Boise",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("1ee7055c-b229-41e4-ae10-0d6019531b71"),
				Code = "PIH",
				Name = "NWS Pocatello",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a16b9285-7d53-4707-85b8-2bec5de37f29"),
				Code = "BYZ",
				Name = "NWS Billings",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("501e077f-b558-48ec-98fc-26413d0d27ad"),
				Code = "GGW",
				Name = "NWS Glasgow",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("7a1e9a80-499b-41aa-aada-bb0fba9b3efb"),
				Code = "TFX",
				Name = "NWS Great Falls",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("4d07a497-918e-4ed9-bcac-a94424521152"),
				Code = "MSO",
				Name = "NWS Missoula",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("30abad4d-994c-4592-9a6e-7adfc49751f6"),
				Code = "LKN",
				Name = "NWS Elko",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("f439c86f-50ae-4e51-819d-c3269506b1f1"),
				Code = "VEF",
				Name = "NWS Las Vegas",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("5c1e32a7-7077-4097-a94f-0c32d21dd08a"),
				Code = "REV",
				Name = "NWS Reno",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("a9203129-327c-4e08-8d18-97e3a879f299"),
				Code = "MFR",
				Name = "NWS Medford",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("bdcd24b8-12fb-4dc2-94c3-e81ee547f90e"),
				Code = "PDT",
				Name = "NWS Pendleton",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("e85d5721-df68-44bb-8b33-d7bc0085e3a2"),
				Code = "PQR",
				Name = "NWS Portland",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("ac7b3431-6ee2-4f8e-8e0f-1fc1523da6b3"),
				Code = "SLC",
				Name = "NWS Salt Lake City",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("adfcd9cf-b147-4e8d-984c-888884dbcb09"),
				Code = "SEW",
				Name = "NWS Seattle",
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			},
			new()
			{
				Id = Guid.Parse("0de3e30b-14a6-4411-9897-9e3ab8585681"),
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
