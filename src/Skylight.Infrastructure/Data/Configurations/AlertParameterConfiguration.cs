using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Domain.Alerts.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public class AlertParameterConfiguration : BaseAuditableEntityConfiguration<AlertParameter>
{
	public override void Configure(EntityTypeBuilder<AlertParameter> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.Key);

		builder
			.Property(x => x.Key)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);

		builder
			.Property(x => x.Value)
			.HasMaxLength(DatabaseConfigurations.MaxLengthLong);
	}
}
