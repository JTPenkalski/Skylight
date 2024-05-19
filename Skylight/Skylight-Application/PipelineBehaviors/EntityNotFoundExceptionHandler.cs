using FluentResults;
using MediatR;
using MediatR.Pipeline;
using Skylight.Domain.Exceptions;

namespace Skylight.Application.PipelineBehaviors;

/// <summary>
/// Catches any <see cref="EntityNotFoundException"/> and returns a failed <see cref="Result"/> to the sender.
/// </summary>
public class EntityNotFoundExceptionHandler : IRequestExceptionHandler<IRequest<Result>, Result, EntityNotFoundException>
{
    public Task Handle(IRequest<Result> request, EntityNotFoundException exception, RequestExceptionHandlerState<Result> state, CancellationToken cancellationToken)
    {
        state.SetHandled(Result.Fail(exception.Message));
        
        return Task.CompletedTask;
    }
}
