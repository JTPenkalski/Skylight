using Hangfire;

namespace Skylight.Infrastructure.Jobs.Schedules;

/// <summary>
/// Base utility to simplify the process of scheduling basic, recurring jobs.
/// </summary>
public abstract class BaseJobScheduler<T> : IJobScheduler where T : IJob
{
	public abstract bool TriggerImmediate { get; }

	public abstract string CronSchedule { get; }

	public string Key => typeof(T).Name;

	public bool Schedule(IRecurringJobManager manager)
	{
		manager.AddOrUpdate<T>(
			Key,
			x => x.ProcessAsync(CancellationToken.None),
			CronSchedule);

		return CronSchedule != Cron.Never();
	}
}
