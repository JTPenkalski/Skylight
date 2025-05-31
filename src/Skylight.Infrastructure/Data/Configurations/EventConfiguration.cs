using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Application.Common.Data;
using Skylight.Domain.Common.Events;

namespace Skylight.Infrastructure.Data.Configurations;

public class EventConfiguration : BaseEntityConfiguration<Event>
{
	public override void Configure(EntityTypeBuilder<Event> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.Type);

		builder
			.Property(x => x.Type)
			.HasMaxLength(DatabaseConfigurations.MaxLengthShort);
	}
}
