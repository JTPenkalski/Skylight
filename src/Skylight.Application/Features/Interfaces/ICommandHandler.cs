using Mediator;
using Skylight.Domain.Common.Results;

namespace Skylight.Application.Features.Interfaces;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TCommand"/>.
/// </summary>
public interface ICommandHandler<in TCommand>
	: IRequestHandler<TCommand, Result>
	where TCommand : ICommand;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TCommand"/> command and returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface ICommandHandler<in TCommand, TResponse>
	: IRequestHandler<TCommand, Result<TResponse>>
	where TCommand : ICommand<TResponse>
	where TResponse : IResponse;
