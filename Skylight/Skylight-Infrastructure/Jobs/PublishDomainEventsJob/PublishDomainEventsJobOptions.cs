using Microsoft.Extensions.Options;

namespace Skylight.Infrastructure.Jobs;

public class PublishDomainEventsJobOptions : IOptions<PublishDomainEventsJobOptions>
{
	public const string RootKey = $"Jobs:{nameof(PublishDomainEventsJob)}";

	public PublishDomainEventsJobOptions Value => this;

	public bool Enabled { get; set; } = false;
}
