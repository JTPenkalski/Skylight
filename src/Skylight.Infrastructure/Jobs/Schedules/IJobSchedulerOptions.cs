namespace Skylight.Infrastructure.Jobs.Schedules;

/// <summary>
/// Common configuration for all <see cref="IJobScheduler"/>s.
/// </summary>
public interface IJobSchedulerOptions
{
	/// <summary>
	/// If this job should be scheduled at all.
	/// </summary>
	bool Enabled { get; }

	/// <summary>
	/// The CRON schedule this job executes on.
	/// </summary>
	string Schedule { get; }
}
