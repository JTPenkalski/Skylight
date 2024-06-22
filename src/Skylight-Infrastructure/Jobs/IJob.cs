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
