using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Domain.Common.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public abstract class BaseAuditableEntityConfiguration<T> : BaseEntityConfiguration<T>
	where T : BaseAuditableEntity
{
	public override void Configure(EntityTypeBuilder<T> builder)
	{
		base.Configure(builder);

		builder
			.HasIndex(x => x.CreatedOn);

		builder
			.HasIndex(x => x.ModifiedOn);

		builder
			.HasIndex(x => x.DeletedOn);
	}
}
