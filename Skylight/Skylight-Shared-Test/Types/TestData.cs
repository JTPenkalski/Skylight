using System.Text.Json;

namespace Skylight.Test.Shared;

// TODO: This is broken. Find another way?

/// <summary>
/// A serializable type to support Xunit theories.
/// </summary>
public class TestData<T> : IXunitSerializable
{
	public T? Data { get; set; }

	public static implicit operator TestData<T>(T data) => new() { Data = data };

	public static implicit operator T?(TestData<T> test) => test.Data;

	public void Deserialize(IXunitSerializationInfo info)
	{
		Data = JsonSerializer.Deserialize<T>(info.GetValue<string>(nameof(Data)));
	}

	public void Serialize(IXunitSerializationInfo info)
	{
		info.AddValue(nameof(Data), JsonSerializer.Serialize(Data));
	}
}
