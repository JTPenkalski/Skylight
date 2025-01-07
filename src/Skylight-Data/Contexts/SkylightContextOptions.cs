using Microsoft.Extensions.Options;

namespace Skylight.Data.Contexts;

public class SkylightContextOptions : IOptions<SkylightContextOptions>
{
	public const string RootKey = "SkylightContext";

	public SkylightContextOptions Value => this;

	public bool EnableSensitiveDataLogging { get; set; }

	public bool UseCreateAndDropMigrations { get; set; }
}
