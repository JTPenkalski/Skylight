using Skylight.Application.Common.Data;
using System.Diagnostics;

namespace Skylight.Infrastructure.MigrationWorker;

public sealed class Worker(
	IServiceProvider serviceProvider,
	IHostApplicationLifetime hostApplicationLifetime,
	ILogger<Worker> logger)
	: BackgroundService
{
	public const string ActivitySourceName = nameof(MigrationWorker);
	private static readonly ActivitySource ActivitySource = new(ActivitySourceName);

	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		using Activity? activity = ActivitySource.StartActivity("Database Migration", ActivityKind.Client);

		try
		{
			logger.LogInformation("Starting database migration.");

			using var scope = serviceProvider.CreateScope();
			ISkylightDbContext dbContext = scope.ServiceProvider.GetRequiredService<ISkylightDbContext>();

			await dbContext.MigrateAsync(stoppingToken);

			logger.LogInformation("Completed database migration.");
		}
		catch (Exception ex)
		{
			logger.LogError(ex, "Database migration failed!");

			activity?.AddException(ex);
		}
		finally
		{
			hostApplicationLifetime.StopApplication();
		}
	}
}
