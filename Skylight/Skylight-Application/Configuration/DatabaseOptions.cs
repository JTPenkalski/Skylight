using Microsoft.Extensions.Options;

namespace Skylight.Application.Configuration;

public class DatabaseOptions : IOptions<DatabaseOptions>
{
    public const string RootKey = "Database";

    public DatabaseOptions Value => this;

    public bool EnableSensitiveDataLogging { get; set; }

    public bool UseCreateAndDropMigrations { get; set; }
}
