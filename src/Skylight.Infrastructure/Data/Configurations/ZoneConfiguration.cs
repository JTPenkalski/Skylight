using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class ZoneConfiguration : BaseAuditableEntityConfiguration<Zone>
{
	public override void Configure(EntityTypeBuilder<Zone> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.Code)
			.IsUnique();

		builder
			.Property(x => x.Code)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);
	}
}
