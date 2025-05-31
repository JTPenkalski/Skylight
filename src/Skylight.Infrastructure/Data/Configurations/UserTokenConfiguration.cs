using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Infrastructure.Identity.Users;

namespace Skylight.Infrastructure.Data.Configurations;

public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
{
	public void Configure(EntityTypeBuilder<UserToken> builder)
	{
		builder
			.ToTable("UserTokens");

		// Composite Primary Key from UserId, LoginProvider, and Name
		builder
			.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

		builder
			.Property(l => l.LoginProvider)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(l => l.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);
	}
}
