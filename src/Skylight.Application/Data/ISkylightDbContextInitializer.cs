namespace Skylight.Application.Data;

/// <summary>
/// Seeds a database with initial data.
/// </summary>
public interface ISkylightDbContextInitializer
{
	/// <summary>
	/// Initialize a database and populate with data.
	/// </summary>
	Task InitializeAsync();
}
