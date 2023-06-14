namespace Skylight.Configuration.Options
{
    /// <summary>
    /// Strongly-typed model for database configuration options.
    /// </summary>
    public class DatabaseOptions
    {
        public const string RootKey = "Database";

        public bool EnableSensitiveDataLogging { get; set; }
        public bool UseCreateAndDropMigrations { get; set; }
    }
}