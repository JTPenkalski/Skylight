namespace Skylight.Infrastructure.Jobs;

/// <summary>
/// Required functionality for all background services.
/// </summary>
public interface IJob
{
	/// <summary>
	/// Executes a background process.
	/// </summary>
	Task ProcessAsync(CancellationToken cancellationToken);
}

/// <inheritdoc cref="IJob"/>
public interface IJob<in T>
{
	/// <inheritdoc cref="IJob.ProcessAsync(CancellationToken)"/>
	/// <param name="arguments">Arguments needed for the job to process.</param>
	Task ProcessAsync(T arguments, CancellationToken cancellationToken);
}
