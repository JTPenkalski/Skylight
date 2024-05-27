using MediatR;

namespace Skylight.Infrastructure.Jobs;

public class FetchActiveWeatherAlertsJob(IMediator mediator) : IJob
{
	public async Task ProcessAsync(CancellationToken cancellationToken)
	{
		Console.WriteLine("Hello world");
	}
}
