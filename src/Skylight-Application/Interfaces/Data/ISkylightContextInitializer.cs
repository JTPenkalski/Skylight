namespace Skylight.Application.Interfaces.Data;

/// <summary>
/// Seeds a local database with initial data for testing.
/// </summary>
public interface ISkylightContextInitializer
{
    /// <summary>
    /// Initialize a local database with test data.
    /// </summary>
    Task InitializeAsync();
}
