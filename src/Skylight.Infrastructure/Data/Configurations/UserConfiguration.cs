using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Infrastructure.Identity.Users;

namespace Skylight.Infrastructure.Data.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
	public void Configure(EntityTypeBuilder<User> builder)
	{
		builder
			.ToTable("Users");

		builder
			.HasIndex(x => x.CreatedOn);

		builder
			.HasIndex(x => x.ModifiedOn);

		builder
			.HasIndex(x => x.DeletedOn);

		builder
			.HasIndex(u => u.NormalizedUserName)
			.IsUnique();

		builder
			.HasIndex(u => u.NormalizedEmail);

		builder
			.Property(u => u.ConcurrencyStamp)
			.IsConcurrencyToken();

		builder
			.Property(u => u.UserName)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(u => u.NormalizedUserName)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(u => u.Email)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(u => u.NormalizedEmail)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		// Note: These relationships are configured with no navigation properties
		builder
			.HasMany<UserClaim>()
			.WithOne()
			.HasForeignKey(uc => uc.UserId)
			.IsRequired();

		builder
			.HasMany<UserLogin>()
			.WithOne()
			.HasForeignKey(ul => ul.UserId)
			.IsRequired();

		builder
			.HasMany<UserToken>()
			.WithOne()
			.HasForeignKey(ut => ut.UserId)
			.IsRequired();

		builder
			.HasMany<UserRole>()
			.WithOne()
			.HasForeignKey(ur => ur.UserId)
			.IsRequired();
	}
}
