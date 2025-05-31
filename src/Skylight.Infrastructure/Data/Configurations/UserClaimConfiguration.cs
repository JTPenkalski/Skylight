using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Infrastructure.Identity.Users;

namespace Skylight.Infrastructure.Data.Configurations;

public class UserClaimConfiguration : IEntityTypeConfiguration<UserClaim>
{
	public void Configure(EntityTypeBuilder<UserClaim> builder)
	{
		builder
			.ToTable("UserClaims");
	}
}
