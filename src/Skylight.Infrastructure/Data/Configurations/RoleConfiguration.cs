using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Application.Common.Identity;
using Skylight.Infrastructure.Identity.Roles;
using Skylight.Infrastructure.Identity.Users;

namespace Skylight.Infrastructure.Data.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
	public void Configure(EntityTypeBuilder<Role> builder)
	{
		builder
			.ToTable("Roles");

		builder
			.HasIndex(x => x.CreatedOn);

		builder
			.HasIndex(x => x.ModifiedOn);

		builder
			.HasIndex(x => x.DeletedOn);

		builder
			.HasIndex(r => r.NormalizedName)
			.IsUnique();

		builder
			.Property(r => r.ConcurrencyStamp)
			.IsConcurrencyToken();

		builder
			.Property(u => u.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(u => u.NormalizedName)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		// Note: These relationships are configured with no navigation properties
		builder
			.HasMany<UserRole>()
			.WithOne()
			.HasForeignKey(ur => ur.RoleId)
			.IsRequired();

		builder
			.HasMany<RoleClaim>()
			.WithOne()
			.HasForeignKey(rc => rc.RoleId)
			.IsRequired();

		builder
			.HasData(GetSeed());
	}

	private static Role[] GetSeed()
	{
		Role[] roles =
		[
			new Role
			{
				Id = Guid.Parse("951eb04f-9b26-4f6d-a807-57edfa277efa"),
				Name = SkylightRoles.Admin,
				CreatedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				CreatedBy = SkylightUsers.SystemId,
				ModifiedOn = new DateTimeOffset(2025, 05, 25, 00, 00, 00, TimeSpan.Zero),
				ModifiedBy = SkylightUsers.SystemId,
			}
		];

		return roles;
	}
}
