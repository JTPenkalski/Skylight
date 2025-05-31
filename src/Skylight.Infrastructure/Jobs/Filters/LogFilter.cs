using Hangfire.Server;
using Microsoft.Extensions.Logging;

namespace Skylight.Infrastructure.Jobs.Filters;

public class LogFilter(ILogger<LogFilter> logger) : IServerFilter, IJobFilter
{
	public void OnPerforming(PerformingContext context)
	{
		logger.LogInformation("Starting background job '{JobKey}'.", context.BackgroundJob.Job.Type.Name);
	}

	public void OnPerformed(PerformedContext context)
	{
		logger.LogInformation("Finishing background job '{JobKey}'.", context.BackgroundJob.Job.Type.Name);
	}
}
