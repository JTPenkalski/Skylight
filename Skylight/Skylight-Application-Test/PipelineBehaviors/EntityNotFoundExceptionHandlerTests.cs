using FluentResults;
using MediatR;
using Skylight.Application.Interfaces.Application;
using Skylight.Application.PipelineBehaviors;
using Skylight.Domain.Exceptions;

namespace Skylight.Tests.Application.PipelineBehaviors;

public class EntityNotFoundExceptionHandlerTests
{
    private record TestRequest() : ICommand;
    private record TestResponse() : IResponse;

    private EntityNotFoundExceptionBehavior<TestRequest, Result<TestResponse>> EntityNotFoundExceptionHandler { get; } = new();

    [Fact]
    public async Task Handle_Should_ReturnFailedResultOnEntityNotFoundException()
    {
        // Arrange
        var request = new TestRequest();
        RequestHandlerDelegate<Result<TestResponse>> next = () => throw new EntityNotFoundException();

        // Act
        Result<TestResponse> result = await EntityNotFoundExceptionHandler.Handle(request, next, CancellationToken.None);

        // Assert
        Assert.True(result.IsFailed);
    }

    [Fact]
    public async Task Handle_Should_IgnoreOtherException()
    {
        // Arrange
        var request = new TestRequest();
        RequestHandlerDelegate<Result<TestResponse>> next = () => throw new Exception();

        // Act
        Task<Result<TestResponse>> resultTask = EntityNotFoundExceptionHandler.Handle(request, next, CancellationToken.None);

        // Assert
        await Assert.ThrowsAsync<Exception>(() => resultTask);
    }
}
