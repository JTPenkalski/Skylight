namespace Skylight.Application.Common.Data;

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
