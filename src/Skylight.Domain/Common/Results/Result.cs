namespace Skylight.Domain.Common.Results;

public abstract class Result
{
	public bool IsSuccess => Errors.Count == 0;

	public bool IsFailed => !IsSuccess;

	public IList<Error> Errors { get; protected set; } = [];

	public static Result<T> Success<T>(T? value) =>
		new(value);

	public static Result<T> Fail<T>(Error error) =>
		new(error);
}

public class Result<T> : Result
{
	public T? Value { get; protected set; }

	public Result() : base() { }

	public Result(T? value) : base() =>
		Value = value;

	public Result(Error error) : base() =>
		Errors.Add(error);

	public static implicit operator T?(Result<T> result) =>
		result.Value;

	public static implicit operator Result<T>(T value) =>
		new(value);
}
