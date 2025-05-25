using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Skylight.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlertSenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertSenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlertTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    Level = table.Column<string>(type: "text", nullable: false),
                    EventCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    TypeCode = table.Column<string>(type: "text", nullable: false, computedColumnSql: "COALESCE(\"EventCode\", \"ProductCode\")", stored: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Type = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Payload = table.Column<string>(type: "text", nullable: false),
                    Failures = table.Column<int>(type: "integer", nullable: false),
                    HandledOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Headline = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    Instruction = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    SentOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EffectiveOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    BeginsOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    ExpiresOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    EndsOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    MessageType = table.Column<string>(type: "text", nullable: false),
                    Severity = table.Column<string>(type: "text", nullable: false),
                    Certainty = table.Column<string>(type: "text", nullable: false),
                    Urgency = table.Column<string>(type: "text", nullable: false),
                    Response = table.Column<string>(type: "text", nullable: false),
                    IsEffectuated = table.Column<bool>(type: "boolean", nullable: false),
                    IsExpired = table.Column<bool>(type: "boolean", nullable: false),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_AlertSenders_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AlertSenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alerts_AlertTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AlertTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlertParameters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Key = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "character varying(4096)", maxLength: 4096, nullable: false),
                    AlertId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertParameters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertParameters_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlertZones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlertId = table.Column<Guid>(type: "uuid", nullable: false),
                    ZoneId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    ModifiedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlertZones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlertZones_Alerts_AlertId",
                        column: x => x.AlertId,
                        principalTable: "Alerts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlertZones_Zones_ZoneId",
                        column: x => x.ZoneId,
                        principalTable: "Zones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlertSenders",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "ModifiedBy", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("001382ad-4143-4075-960b-e25939d38c14"), "TOP", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Topeka" },
                    { new Guid("043d5214-8653-4ea4-a7c9-cdc8487d1ccb"), "RAH", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Raleigh North" },
                    { new Guid("06f137a5-aa58-4151-ad4d-999bde3965fd"), "BIS", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Bismarck" },
                    { new Guid("0c1785b4-e0ee-41cf-9862-340dd2a5f7ff"), "MTR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS San Francisco Bay Area" },
                    { new Guid("0de3e30b-14a6-4411-9897-9e3ab8585681"), "OTX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Spokane" },
                    { new Guid("11035a3c-5bea-46e4-bea5-a1733fe59b53"), "EPZ", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS El Paso" },
                    { new Guid("12f93626-4d50-408e-91a3-b6cdf406ef2d"), "FSD", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Sioux Fall" },
                    { new Guid("12f9c72d-97ce-4e82-aeb5-7a7ae999a6c8"), "TBW", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Tampa" },
                    { new Guid("145c5051-c688-4487-a803-e83f4fcabc1e"), "RLX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Charlesto" },
                    { new Guid("17b93477-b647-420b-bcc0-75eefb6734d1"), "TSA", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Tulsa" },
                    { new Guid("1833e572-775d-42e8-a10d-894947ba4c72"), "JKL", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Jackson" },
                    { new Guid("19c76882-fb3d-488a-8e9d-a7dd67bb3940"), "MLB", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Melbourne" },
                    { new Guid("1c9e022b-975f-411f-b890-bad1ba9a7cca"), "AMA", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Amarillo" },
                    { new Guid("1dd67163-cb82-4f18-9a7e-399728669a78"), "ILM", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Wilmington" },
                    { new Guid("1ee7055c-b229-41e4-ae10-0d6019531b71"), "PIH", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Pocatello" },
                    { new Guid("20e3a576-f20b-4c93-9558-4bfe90fe1503"), "UNR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Rapid City" },
                    { new Guid("2f714d64-8bcc-4b56-ab34-fadddece36f7"), "SGF", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Springfield" },
                    { new Guid("306fb3e4-897a-4ef5-bcf7-607232c4a897"), "BUF", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Buffalo" },
                    { new Guid("30abad4d-994c-4592-9a6e-7adfc49751f6"), "LKN", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Elko" },
                    { new Guid("3459fab2-416c-4ead-a5a1-c363bcc37806"), "TWC", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Tucson" },
                    { new Guid("36600f01-c7cf-4d9c-a14d-898f48dafe4c"), "FGZ", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Flagstaff" },
                    { new Guid("377c698f-fe43-48cb-9df6-52af611cb08c"), "GSP", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Greenville/Spartanburg" },
                    { new Guid("37cf2a4a-9c9c-4c01-96a3-3ac4f392505f"), "LWX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Baltimore/Washington" },
                    { new Guid("38e3c394-1b3e-479e-8400-3dbb76fddd7f"), "EKA", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Eureka" },
                    { new Guid("38feda61-88ca-4d20-90b1-06e65e9e7f11"), "LBF", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS North Platte" },
                    { new Guid("3b567347-e762-4598-a750-e9f58ae4903c"), "TAE", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Tallahassee" },
                    { new Guid("3d595d50-0216-456b-b95e-416ad2c7771e"), "OHX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Nashville" },
                    { new Guid("4350f374-9061-4c6f-bf5c-2bae508b8129"), "LMK", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Louisville" },
                    { new Guid("4385ba25-5a19-4928-9433-37df725f4752"), "BOX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Boston/Norton" },
                    { new Guid("468481f8-7ac3-4d62-9873-e086d1c349c5"), "EWX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Austin/San Antonio" },
                    { new Guid("4b2169a9-c48c-4372-8a98-693f4e7ca190"), "LSX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS St. Louis" },
                    { new Guid("4d07a497-918e-4ed9-bcac-a94424521152"), "MSO", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Missoula" },
                    { new Guid("4d99506c-6023-4708-b48c-06f8e534d6ba"), "HFO", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Honolulu" },
                    { new Guid("4e4e6437-65d6-4505-b7b7-005d99cf182e"), "HGX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Houston/Galveston" },
                    { new Guid("4fd91921-a691-4684-824a-8dcdde63bca9"), "LCH", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Lake Charles" },
                    { new Guid("501e077f-b558-48ec-98fc-26413d0d27ad"), "GGW", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Glasgow" },
                    { new Guid("52c35b4a-653b-46f1-bd82-0e474c75893f"), "AFC", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Anchorage" },
                    { new Guid("53ab0911-8a41-4a93-bd2d-93220f9cf4dd"), "HNX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS San Joaquin Valley" },
                    { new Guid("59a6c9a8-95db-4d8a-8038-02962e10fe14"), "ILX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Lincoln" },
                    { new Guid("5a3bbe70-5f16-4290-959c-ec8813a2ae82"), "LOT", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Chicago" },
                    { new Guid("5a8ca515-8cf2-4213-a974-fb1317e7e649"), "FWD", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Fort Worth/Dallas" },
                    { new Guid("5acdae5e-4b49-4053-bf43-2b0083512882"), "ARX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS La Crosse" },
                    { new Guid("5c1e32a7-7077-4097-a94f-0c32d21dd08a"), "REV", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Reno" },
                    { new Guid("5f85bc59-5a63-4052-b8bc-592193317846"), "LZK", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Little Rock" },
                    { new Guid("5fcf256c-d0ca-4533-b7e2-e8cce2514c47"), "GRR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Grand Rapids" },
                    { new Guid("63bacad6-0460-4ef9-bad5-7214ba9b5fe7"), "MRX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Morristown" },
                    { new Guid("65877500-3987-49bc-9db8-e71265d742be"), "PAH", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Paducah" },
                    { new Guid("668d6067-e7c9-47fc-8269-c9c6a4cbf1aa"), "PSR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Phoenix" },
                    { new Guid("6ba0bf0b-cdb6-456f-9d71-66bdc8128ea2"), "ICT", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Wichita" },
                    { new Guid("6d80e8f5-d7fe-45dc-91f2-70ef33d69c02"), "GLD", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Goodland" },
                    { new Guid("70cf1e8a-1cec-4a3b-8e65-939ecb780622"), "DLH", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Duluth" },
                    { new Guid("7216a99c-49b2-446c-971f-849ea0642b10"), "MQT", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Marquette" },
                    { new Guid("7a1e9a80-499b-41aa-aada-bb0fba9b3efb"), "TFX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Great Falls" },
                    { new Guid("7db25e25-a0d7-4237-8163-d732a2366fbc"), "DDC", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Dodge City" },
                    { new Guid("82899735-8877-4c12-b8a0-e679cbe1582a"), "CRP", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Corpus Christi" },
                    { new Guid("847700b4-2040-4669-8904-73f85be84b88"), "RNK", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Blacksburg" },
                    { new Guid("8505dace-9d60-431c-a7ef-278ce6ffc5b6"), "MHX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Newport/Morehead City" },
                    { new Guid("879c0b7e-24ce-4deb-abda-51a2ee90b6c0"), "SJT", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS San Angelo" },
                    { new Guid("8a2c6cb5-82ce-4e17-a778-e4adfaef7056"), "GJT", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Grand Junction" },
                    { new Guid("8cd29888-8dc8-40e9-bf97-76bb3761ed80"), "IWX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Northern Indiana" },
                    { new Guid("8f63fbe1-3e28-4fdd-983b-0a2844bcc59b"), "MPX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Twin Cities" },
                    { new Guid("8fd8f311-3dc2-427e-8182-dfc45549cee0"), "PHI", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Mount Holly/Philadelphia" },
                    { new Guid("9081c006-67ad-486c-b9b6-d75d961ea004"), "MOB", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Mobile/Pensacola" },
                    { new Guid("9318342e-964e-4af4-98c7-98f459d012d1"), "GUM", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Guam" },
                    { new Guid("9678f207-df1b-428e-8397-a184f3a0ee48"), "KEY", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Key West" },
                    { new Guid("97969901-52ca-437d-a226-770dfc538f50"), "LUB", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Lubbock" },
                    { new Guid("9871fad4-16b2-4c66-8e57-45e98644dbb4"), "LOX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Los Angeles" },
                    { new Guid("a0af1fea-d647-42cd-b5b8-f55b89009ef2"), "MKX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Milwaukee/Sullivan" },
                    { new Guid("a16b9285-7d53-4707-85b8-2bec5de37f29"), "BYZ", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Billings" },
                    { new Guid("a60b1be3-122e-429d-a31c-4b22e29b8f9f"), "ABR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Aberdee" },
                    { new Guid("a8578756-e0c0-4b44-86bf-b54d20181964"), "BMX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Birmingham" },
                    { new Guid("a9203129-327c-4e08-8d18-97e3a879f299"), "MFR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Medford" },
                    { new Guid("ac3ac668-301c-4e9c-89e6-f0b2fcf5de56"), "BGM", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Binghamton" },
                    { new Guid("ac7b3431-6ee2-4f8e-8e0f-1fc1523da6b3"), "SLC", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Salt Lake City" },
                    { new Guid("ada98b38-ea71-49a6-9066-86c6e94e0ae9"), "DMX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Des Moines" },
                    { new Guid("adfcd9cf-b147-4e8d-984c-888884dbcb09"), "SEW", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Seattle" },
                    { new Guid("aff2166a-dc65-4dbb-b112-06f84b30cc50"), "GID", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Hastings" },
                    { new Guid("b03efd4a-a90d-4514-9eff-a011ac77d256"), "MFL", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Miami" },
                    { new Guid("b08b0b49-fb75-46a5-8d0a-a60240a79e3a"), "PUB", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Pueblo" },
                    { new Guid("b3a78ffd-37a2-4663-928f-81feb479d205"), "CHS", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Charlesto" },
                    { new Guid("b513fcfc-40ff-480c-a73a-9c4a6823d729"), "APX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Gaylord" },
                    { new Guid("b886c96b-c07d-4dbc-afe6-ce4dc1e22b33"), "MEG", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Memphis" },
                    { new Guid("b9984c93-c83a-4574-baa3-39951034b4ba"), "JAN", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Jackson" },
                    { new Guid("b99be2df-a3df-4dc2-8509-565626817412"), "DTX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Detroit/Pontiac" },
                    { new Guid("bb03d5e5-a868-485e-aa14-c6c157d95036"), "FFC", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Peachtree City" },
                    { new Guid("bc6c324b-5cd8-4f54-907e-d0845f11444d"), "GYX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Gray/Portland" },
                    { new Guid("bdcd24b8-12fb-4dc2-94c3-e81ee547f90e"), "PDT", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Pendleton" },
                    { new Guid("bf6ebce9-528b-407f-a9cb-0a19db00ff81"), "SGX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS San Diego" },
                    { new Guid("c1248289-4f30-49dd-8988-c24e05d6bcd3"), "HUN", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Huntsville" },
                    { new Guid("c3c91064-75c3-44e1-91c5-feb79f6e819c"), "CYS", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Cheyenne" },
                    { new Guid("ca12e950-6b48-4f5d-b992-b386a800d009"), "LIX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS New Orleans/Baton Rouge" },
                    { new Guid("cc5c48f4-196e-4673-92ed-45d62bf61d0b"), "OUN", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Norman" },
                    { new Guid("cde34b64-e24c-4af9-ba4e-56c371b2ff12"), "FGF", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Grand Fork" },
                    { new Guid("d0386bc4-d1e6-4ab9-a525-3f97a8fda648"), "PBZ", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Pittsburgh" },
                    { new Guid("d55e1e3c-aae1-49df-ab3d-90406e37bd12"), "GRB", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Green Bay" },
                    { new Guid("d8bd481c-d915-4bba-bc88-a7cf70ce4e4e"), "CAR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Caribou" },
                    { new Guid("d9ec8bb2-7859-488b-82d0-c7cccee874e5"), "CTP", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS State College" },
                    { new Guid("da48fcf2-9a36-4cdc-abab-c1734a650ac2"), "ILN", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Wilmington" },
                    { new Guid("db1a00b0-3412-4fa7-b0b4-30bbbcda7a2d"), "MAF", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Midland/Odessa" },
                    { new Guid("dc47825b-4ebc-4afc-9cc3-91593ce3beee"), "STO", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Sacramento" },
                    { new Guid("dfc086c9-3a68-4368-b77a-c69f7f018aa9"), "IND", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Indianapolis" },
                    { new Guid("e0a630eb-4707-4738-9a90-d901aab30d54"), "RIW", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Riverton" },
                    { new Guid("e13cde99-0296-4832-8c5f-e7ae4115d26c"), "OKX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS New York" },
                    { new Guid("e23cb76a-757a-4317-a8e6-9dcd9efdfcf5"), "EAX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Kansas City/Pleasant Hill" },
                    { new Guid("e34917c4-1212-4e08-8299-e3a5896fc982"), "CAE", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Columbia" },
                    { new Guid("e4172543-8af7-49c5-9c6a-bb0074c47870"), "BTV", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Burlington" },
                    { new Guid("e85d5721-df68-44bb-8b33-d7bc0085e3a2"), "PQR", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Portland" },
                    { new Guid("e86bf576-78fb-4065-ab44-e934b7959e4a"), "AFG", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Fairbanks" },
                    { new Guid("e8e52f2a-a403-4cc1-a550-c651dcb607c3"), "SJU", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS San Jua" },
                    { new Guid("eac912a6-595b-4166-b816-660bfcedeffa"), "AKQ", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Wakefield" },
                    { new Guid("ead8d492-74f8-46ed-a590-223329debeca"), "SHV", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Shreveport" },
                    { new Guid("ec13a114-e78e-4c65-9d00-bb5140d36329"), "BOU", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Denver/Boulder" },
                    { new Guid("ec9c708a-f0a2-4fb8-a9fb-77dafc6483d4"), "ALY", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Albany" },
                    { new Guid("f04af92c-8c67-4a49-859f-79252c135a7b"), "BOI", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Boise" },
                    { new Guid("f04e98af-86f7-4535-babf-6e729ff84275"), "ABQ", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Albuquerque" },
                    { new Guid("f34dc1bd-fe8d-4f39-98f6-25977a0b0800"), "CLE", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Cleveland" },
                    { new Guid("f439c86f-50ae-4e51-819d-c3269506b1f1"), "VEF", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Las Vegas" },
                    { new Guid("f468413b-b9d3-4590-aeb3-fea78abbec2f"), "JAX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Jacksonville" },
                    { new Guid("fa675f2a-f105-48f2-8219-4beb767d1ec4"), "OAX", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Omaha/Valley" },
                    { new Guid("fc8e9ba3-ddd1-4fa9-9656-5e85e846a534"), "DVN", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Quad Cities" },
                    { new Guid("fe44cb6c-65d3-48cb-9ae8-7f3e5735d871"), "BRO", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Brownsville" },
                    { new Guid("ff7f49da-b154-4fd5-980d-1790046c4c58"), "AJK", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "NWS Juneau" }
                });

            migrationBuilder.InsertData(
                table: "AlertTypes",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "EventCode", "Level", "ModifiedBy", "ModifiedOn", "Name", "ProductCode" },
                values: new object[,]
                {
                    { new Guid("43f44630-21db-4421-871d-f2d327489552"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Issued to inform the public, emergency management, and other cooperating agencies that flash flooding is in progress, imminent, or highly likely.", "FFW", "Warning", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Flash Flood Warning", "FFW" },
                    { new Guid("4a4461ce-2b48-4dfb-938b-e40a8ce35437"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A weather statement issued when a specified hazard is approaching advisory criteria or to highlight upcoming significant weather events. These are issued to advise of ongoing or imminent hazardous convective weather expected to continue/dissipate or expand/decrease in geographical coverage within the next one to two hours, major events forecast to occur beyond a six-hour timeframe (such as substantial temperature changes, dense fog and winter weather events), sub-severe thunderstorms (containing sustained winds or gusts of 40–57 mph (64–92 km/h) and/or hail less than one inch (2.5 cm) in diameter, in addition to frequent to continuous lightning and/or funnel clouds not expected to become a tornado threat), or to outline high-impact events supplementary to information contained in other hazardous weather products (such as black ice, short-duration heavy snow or lake-effect snow bands expected to briefly reduce visibility, heavy rainfall not expected to cause flooding, heat index or wind chill values expected to approach \"advisory\" criteria for one or two hours, or local areas of blowing dust where wind is below advisory criteria).", null, "Advisory", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Special Weather Statement", "SPS" },
                    { new Guid("4a4f23be-9135-4bcb-bb19-7f39a8a8a25d"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This is issued by the National Weather Service when conditions are favorable for the development of tornadoes in and close to the watch area. Their size can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They normally are issued well in advance of the actual occurrence of severe weather. During the watch, people should review tornado safety rules and be prepared to move a place of safety if threatening weather approaches.", "TOA", "Watch", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tornado Watch", "WOU" },
                    { new Guid("5434ef57-6bd0-4dda-8e72-bde8fc4bb7d5"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "In hydrologic terms, a statement by the NWS which provides follow-up information on flash flood watches and warnings.", "FFS", "Advisory", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Flash Flood Statement", "FFS" },
                    { new Guid("5e82b31c-c3f7-4911-8d54-2944d6782ba8"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This is issued when a tornado is indicated by the WSR-88D radar or sighted by spotters; therefore, people in the affected area should seek safe shelter immediately. They can be issued without a Tornado Watch being already in effect. They are usually issued for a duration of around 30 minutes.", "TOW", "Warning", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Tornado Warning", "TOR" },
                    { new Guid("a312351a-fb7b-40bd-9e9d-685d0840ed01"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "Issued to indicate current or developing hydrologic conditions that are favorable for flash flooding in and close to the watch area, but the occurrence is neither certain or imminent.", "FFA", "Watch", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Flash Flood Watch", "FFA" },
                    { new Guid("a349126f-92f1-4222-a3cf-bd105b7764f5"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This is issued when either a severe thunderstorm is indicated by the WSR-88D radar or a spotter reports a thunderstorm producing hail one inch or larger in diameter and/or winds equal or exceed 58 miles an hour; therefore, people in the affected area should seek safe shelter immediately. Severe thunderstorms can produce tornadoes with little or no advance warning. Lightning frequency is not a criteria for issuing a severe thunderstorm warning. They are usually issued for a duration of one hour. They can be issued without a Severe Thunderstorm Watch being already in effect.", "SVW", "Warning", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Severe Thunderstorm Warning", "SVR" },
                    { new Guid("be8f23f2-23b1-4f6a-9919-e48d854cb243"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "This is issued by the National Weather Service when conditions are favorable for the development of severe thunderstorms in and close to the watch area. A severe thunderstorm by definition is a thunderstorm that produces one inch hail or larger in diameter and/or winds equal or exceed 58 miles an hour. The size of the watch can vary depending on the weather situation. They are usually issued for a duration of 4 to 8 hours. They are normally issued well in advance of the actual occurrence of severe weather. During the watch, people should review severe thunderstorm safety rules and be prepared to move a place of safety if threatening weather approaches.", "SVA", "Watch", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Severe Thunderstorm Watch", "WOU" },
                    { new Guid("c8a66177-6201-4d9b-b007-f66a7cc090a3"), new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, "A National Weather Service product which provides follow up information on severe weather conditions (severe thunderstorm or tornadoes) which have occurred or are currently occurring.", null, "Advisory", new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Severe Weather Statement", "SVS" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "ModifiedBy", "ModifiedOn", "Name", "NormalizedName" },
                values: new object[] { new Guid("951eb04f-9b26-4f6d-a807-57edfa277efa"), null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), null, null, new Guid("11111111-0000-0000-0000-000000000000"), new DateTimeOffset(new DateTime(2025, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_AlertParameters_AlertId",
                table: "AlertParameters",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertParameters_CreatedOn",
                table: "AlertParameters",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertParameters_DeletedOn",
                table: "AlertParameters",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertParameters_Key",
                table: "AlertParameters",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_AlertParameters_ModifiedOn",
                table: "AlertParameters",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_CreatedOn",
                table: "Alerts",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_DeletedOn",
                table: "Alerts",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_EffectiveOn",
                table: "Alerts",
                column: "EffectiveOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_ExpiresOn",
                table: "Alerts",
                column: "ExpiresOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_ModifiedOn",
                table: "Alerts",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_SenderId",
                table: "Alerts",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_TypeId",
                table: "Alerts",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertSenders_Code",
                table: "AlertSenders",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AlertSenders_CreatedOn",
                table: "AlertSenders",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertSenders_DeletedOn",
                table: "AlertSenders",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertSenders_ModifiedOn",
                table: "AlertSenders",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertTypes_CreatedOn",
                table: "AlertTypes",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertTypes_DeletedOn",
                table: "AlertTypes",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertTypes_EventCode",
                table: "AlertTypes",
                column: "EventCode");

            migrationBuilder.CreateIndex(
                name: "IX_AlertTypes_ModifiedOn",
                table: "AlertTypes",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertTypes_ProductCode",
                table: "AlertTypes",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_AlertTypes_ProductCode_EventCode",
                table: "AlertTypes",
                columns: new[] { "ProductCode", "EventCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AlertZones_AlertId",
                table: "AlertZones",
                column: "AlertId");

            migrationBuilder.CreateIndex(
                name: "IX_AlertZones_CreatedOn",
                table: "AlertZones",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertZones_DeletedOn",
                table: "AlertZones",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertZones_ModifiedOn",
                table: "AlertZones",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "IX_AlertZones_ZoneId",
                table: "AlertZones",
                column: "ZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_Type",
                table: "Events",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_CreatedOn",
                table: "Roles",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_DeletedOn",
                table: "Roles",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_ModifiedOn",
                table: "Roles",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CreatedOn",
                table: "Users",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedOn",
                table: "Users",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedOn",
                table: "Users",
                column: "ModifiedOn");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_Code",
                table: "Zones",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zones_CreatedOn",
                table: "Zones",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_DeletedOn",
                table: "Zones",
                column: "DeletedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Zones_ModifiedOn",
                table: "Zones",
                column: "ModifiedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlertParameters");

            migrationBuilder.DropTable(
                name: "AlertZones");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "Zones");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "AlertSenders");

            migrationBuilder.DropTable(
                name: "AlertTypes");
        }
    }
}
