using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Diagnostics;

namespace Skylight.AppHost.Extensions;

public static class ResourceBuilderExtensions
{
	/// <summary>
	/// Adds a command to the resource that opens a new browser tab to <paramref name="url"/>.
	/// </summary>
	/// <param name="name">The internal name of the command.</param>
	/// <param name="displayName">The display name of the command.</param>
	/// <param name="url">The URL to open.</param>
	/// <returns>The modified <see cref="IResourceBuilder{T}"/>.</returns>
	public static IResourceBuilder<T> WithBrowserCommand<T>(
		this IResourceBuilder<T> builder,
		string name,
		string displayName,
		string url)
		where T : IResource =>
		builder.WithCommand(
			name,
			displayName,
			executeCommand: context =>
			{
				var result = new ExecuteCommandResult
				{
					Success = true,
				};

				try
				{
					Process.Start(
						new ProcessStartInfo(url)
						{
							UseShellExecute = true,
						});
				}
				catch (Exception ex)
				{
					result = new ExecuteCommandResult
					{
						Success = false,
						ErrorMessage = ex.Message
					};
				}

				return Task.FromResult(result);
			},
			commandOptions: new CommandOptions
			{
				IconName = "Document",
				IconVariant = IconVariant.Filled,
				UpdateState = static context => context.ResourceSnapshot.HealthStatus == HealthStatus.Healthy
					? ResourceCommandState.Enabled
					: ResourceCommandState.Disabled,
			});
}
