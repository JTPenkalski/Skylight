using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Skylight.Domain.Common.Entities;

namespace Skylight.Infrastructure.Data.Configurations;

public abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
	where T : BaseEntity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder
			.Property(x => x.Id)
			.ValueGeneratedNever();

		builder
			.Ignore(x => x.Events);
	}
}
