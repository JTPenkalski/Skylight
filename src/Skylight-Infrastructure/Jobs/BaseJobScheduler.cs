using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Skylight.Infrastructure.Jobs;

/// <summary>
/// Base utility to simplify the process of scheduling basic, recurring jobs.
/// </summary>
public abstract class BaseJobScheduler<T> : IJobScheduler where T : IJob
{
    public abstract string CronSchedule { get; }

	public string Key => typeof(T).Name;

	public void Schedule(IApplicationBuilder app, IConfiguration configuration)
	{
        RecurringJob.AddOrUpdate<T>(
            Key,
            x => x.ProcessAsync(CancellationToken.None),
            CronSchedule);
    }
}
