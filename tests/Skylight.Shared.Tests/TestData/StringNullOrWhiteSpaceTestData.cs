using Xunit;

namespace Skylight.Shared.Tests.TestData;

/// <summary>
/// Test data for common <see cref="string.IsNullOrWhiteSpace(string?)"/> checks.
/// </summary>
public class StringNullOrWhiteSpaceTestData : TheoryData<string?>
{
	public StringNullOrWhiteSpaceTestData() : base()
	{
		Add(null!);
		Add(string.Empty);
		Add(" ");
		Add("\t");
		Add("\n");
	}
}
