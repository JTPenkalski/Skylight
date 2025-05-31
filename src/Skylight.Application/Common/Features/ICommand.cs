using Mediator;
using Skylight.Application.Common.Results;

namespace Skylight.Application.Common.Features;

/// <summary>
/// Denotes an application command.
/// </summary>
public interface ICommand
	: IRequest<Result>;

/// <summary>
/// Denotes an application command that returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface ICommand<TResponse>
	: IRequest<Result<TResponse>>
	where TResponse : IResponse;
