using System.Diagnostics.CodeAnalysis;

namespace Skylight.Domain.Common.Results;

public class Result
{
	private readonly List<Error> _errors = [];

	public bool IsSuccess => Errors.Count == 0;

	public bool IsFailed => !IsSuccess;

	public IReadOnlyList<Error> Errors => _errors;

	internal Result(params IEnumerable<Error> errors) =>
		AddErrors(errors);

	public static Result Success() =>
		new();

	public static Result<T> Success<T>(T? value) =>
		new(value);

	public static Result Fail(params IEnumerable<Error> errors) =>
		new(errors);

	public static Result<T> Fail<T>(params IEnumerable<Error> errors) =>
		new(errors);

	public static Result<IEnumerable<T?>> Merge<T>(params IEnumerable<Result<T>> results)
	{
		IEnumerable<T?> values = results.Select(x => x.Value);
		IEnumerable<Error> errors = results.SelectMany(x => x.Errors);

		var result = new Result<IEnumerable<T?>>(values, errors);

		return result;
	}

	public override string ToString() =>
		$"IsSuccess = {IsSuccess}; Errors = {string.Join(',', Errors)}";

	public void AddErrors(params IEnumerable<Error> errors) =>
		_errors.AddRange(errors);
}

public class Result<T> : Result
{
	public Result() : base() { }

	internal Result(T? value) : base() =>
		Value = value;

	internal Result(T? value, params IEnumerable<Error> errors) : base(errors) =>
		Value = value;

	internal Result(params IEnumerable<Error> errors) : base(errors) { }

	public static implicit operator T?(Result<T> result) =>
		result.Value;

	public static implicit operator Result<T>(T value) =>
		new(value);

	public T? Value { get; protected set; }

	public override string ToString() =>
		$"Value = {Value}; IsSuccess = {IsSuccess}; Errors = {string.Join(',', Errors)}";

	public bool TryGetValue([NotNullWhen(true)] out T? value)
	{
		if (IsSuccess && Value is not null)
		{
			value = Value;
			return true;
		}

		value = default;
		return false;
	}
}
