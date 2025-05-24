using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertTypeConfiguration : BaseAuditableEntityConfiguration<AlertType>
{
	public override void Configure(EntityTypeBuilder<AlertType> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.ProductCode);

		builder
			.HasIndex(x => x.EventCode);

		builder
			.HasIndex(x => new { x.ProductCode, x.EventCode })
			.IsUnique();

		builder
			.Property(x => x.ProductCode)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.EventCode)
			.HasMaxLength(DatabaseConfigurations.MaxLengthCode);

		builder
			.Property(x => x.Name)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(x => x.Description)
			.HasMaxLength(DatabaseConfigurations.MaxLengthLong);

		builder
			.Property(x => x.TypeCode)
			.HasComputedColumnSql(@$"COALESCE(""{nameof(AlertType.EventCode)}"", ""{nameof(AlertType.ProductCode)}"")", stored: true);
	}
}
