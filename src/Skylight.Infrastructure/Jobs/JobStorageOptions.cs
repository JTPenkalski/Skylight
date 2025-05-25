namespace Skylight.Infrastructure.Jobs;

public class JobStorageOptions
{
	public const string RootKey = "Jobs:Storage";

	public int QueuePollInterval { get; set; } = 15;

	public int InvisibilityTimeout { get; set; } = 10;
}
