using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;

namespace Skylight.Infrastructure.Jobs;

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
    /// Schedules an individual <see cref="IJob"/> process.
    /// </summary>
    /// <param name="app">The app to schedule the job in.</param>
    /// <param name="configuration">The app's configuration to configure the job with.</param>
    void Schedule(IApplicationBuilder app, IConfiguration configuration);
}
