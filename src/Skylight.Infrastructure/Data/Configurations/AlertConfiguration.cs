using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertConfiguration : BaseAuditableEntityConfiguration<Alert>
{
	public override void Configure(EntityTypeBuilder<Alert> builder)
	{
		base.Configure(builder);

		builder
			.Property(x => x.Headline)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(x => x.Description)
			.HasMaxLength(DatabaseConfigurations.MaxLengthLong);

		builder
			.Property(x => x.Instruction)
			.HasMaxLength(DatabaseConfigurations.MaxLengthLong);

		builder
			.HasIndex(x => x.EffectiveOn);

		builder
			.HasIndex(x => x.ExpiresOn);
	}
}
