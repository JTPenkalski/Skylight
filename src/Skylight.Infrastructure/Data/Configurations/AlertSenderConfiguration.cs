using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertSenderConfiguration : BaseAuditableEntityConfiguration<AlertSender>
{
	public override void Configure(EntityTypeBuilder<AlertSender> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.Code);

		builder
			.Property(x => x.Code)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);
	}
}
