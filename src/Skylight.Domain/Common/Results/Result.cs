namespace Skylight.Domain.Common.Results;

public abstract class Result
{
	private readonly List<Error> _errors = [];

	public bool IsSuccess => Errors.Count == 0;

	public bool IsFailed => !IsSuccess;

	public IReadOnlyList<Error> Errors => _errors;

	public static Result<T> Success<T>(T? value) =>
		new(value);

	public static Result<T> Fail<T>(params IEnumerable<Error> errors) =>
		new(errors);

	public void AddErrors(params IEnumerable<Error> errors) =>
		_errors.AddRange(errors);
}

public class Result<T> : Result
{
	public Result() : base() { }

	internal Result(T? value) : base() =>
		Value = value;

	internal Result(params IEnumerable<Error> errors) : base() =>
		AddErrors(errors);

	public static implicit operator T?(Result<T> result) =>
		result.Value;

	public static implicit operator Result<T>(T value) =>
		new(value);

	public T? Value { get; protected set; }
}
