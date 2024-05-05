using FluentResults;
using MediatR;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Denotes a service that handles a <typeparamref name="TCommand"/>.
/// </summary>
public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand { }

/// <summary>
/// Denotes a service that handles a <typeparamref name="TCommand"/> command and returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse> { }
