using FluentResults;
using MediatR;

namespace Skylight.Application.Interfaces.Application;

/// <summary>
/// Denotes an application command.
/// </summary>
public interface ICommand : IRequest<Result> { }

/// <summary>
/// Denotes an application command that returns a <typeparamref name="TResponse"/>.
/// </summary>
public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
