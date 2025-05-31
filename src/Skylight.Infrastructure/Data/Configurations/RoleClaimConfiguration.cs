using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Infrastructure.Identity.Roles;

namespace Skylight.Infrastructure.Data.Configurations;

public class RoleClaimConfiguration : IEntityTypeConfiguration<RoleClaim>
{
	public void Configure(EntityTypeBuilder<RoleClaim> builder)
	{
		builder
			.ToTable("RoleClaims");
	}
}
