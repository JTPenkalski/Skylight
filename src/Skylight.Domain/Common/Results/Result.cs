namespace Skylight.Domain.Common.Results;

public class Result
{
	private readonly List<Error> _errors = [];

	public bool IsSuccess { get; protected set; }

	public bool IsFailed =>
		!IsSuccess;

	public IReadOnlyList<Error> Errors =>
		_errors;

	protected Result(bool isSuccess) =>
		IsSuccess = isSuccess;

	public void AddError(Error error) =>
		_errors.Add(error);
}

public class Result<T> : Result
{
	public T? Value { get; protected set; }

	public Result(T? value)
		: base(true) =>
		Value = value;

	public Result(Error error)
		: base(false) =>
		AddError(error);

	public static implicit operator T?(Result<T> result) =>
		result.Value;

	public static implicit operator Result<T>(T value) =>
		new(value);

	public static Result<T> Success(T? value) =>
		new(value);

	public static Result<T> Fail(Error error) =>
		new(error);
}
