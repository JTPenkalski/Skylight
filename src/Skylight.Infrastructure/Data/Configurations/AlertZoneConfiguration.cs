using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertZoneConfiguration : BaseAuditableEntityConfiguration<AlertZone>
{
	public override void Configure(EntityTypeBuilder<AlertZone> builder)
	{
		base.Configure(builder);

		builder.ToTable("AlertZones");
	}
}
