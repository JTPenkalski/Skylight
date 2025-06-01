using Hangfire;

namespace Skylight.Infrastructure.Jobs.Schedules;

/// <summary>
/// Base utility to simplify the process of scheduling basic, recurring jobs.
/// </summary>
public abstract class BaseJobScheduler<TJob> : IJobScheduler
	where TJob : IJob
{
	public abstract bool TriggerImmediate { get; }

	public abstract string CronSchedule { get; }

	public string Key => typeof(TJob).Name;

	public bool Schedule(IRecurringJobManager manager)
	{
		manager.AddOrUpdate<TJob>(
			Key,
			x => x.ProcessAsync(CancellationToken.None),
			CronSchedule);

		return CronSchedule != Cron.Never();
	}
}

/// <inheritdoc cref="BaseJobScheduler{TJob}"/>
public abstract class BaseJobScheduler<TJob, TArguments> : IJobScheduler
	where TJob : IJob<TArguments>
{
	public abstract bool TriggerImmediate { get; }

	public abstract string CronSchedule { get; }

	public abstract TArguments Arguments { get; }

	public string Key => typeof(TJob).Name;

	public bool Schedule(IRecurringJobManager manager)
	{
		manager.AddOrUpdate<TJob>(
			Key,
			x => x.ProcessAsync(Arguments, CancellationToken.None),
			CronSchedule);

		return CronSchedule != Cron.Never();
	}
}
