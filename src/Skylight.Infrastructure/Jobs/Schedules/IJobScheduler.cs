using Hangfire;

namespace Skylight.Infrastructure.Jobs.Schedules;

/// <summary>
/// Orchestrates the scheduling of <see cref="IJob"/> processes.
/// </summary>
public interface IJobScheduler
{
	/// <summary>
	/// A unique job key assigned from this <see cref="IJobScheduler"/>.
	/// </summary>
	string Key { get; }

	/// <summary>
	/// If this job should be triggered immediately upon startup.
	/// </summary>
	bool TriggerImmediate { get; }

	/// <summary>
	/// Schedules an individual <see cref="IJob"/> process.
	/// </summary>
	/// <param name="manager">The job manager service to schedule the jobs.</param>
	/// <returns>If the job was successfully scheduled or not.</returns>
	bool Schedule(IRecurringJobManager manager);
}
