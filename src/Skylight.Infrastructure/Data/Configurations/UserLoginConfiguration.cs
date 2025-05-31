using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Infrastructure.Identity.Users;

namespace Skylight.Infrastructure.Data.Configurations;

public class UserLoginConfiguration : IEntityTypeConfiguration<UserLogin>
{
	public void Configure(EntityTypeBuilder<UserLogin> builder)
	{
		builder
			.ToTable("UserLogins");

		builder
			.Property(l => l.LoginProvider)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(l => l.ProviderKey)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);
	}
}
