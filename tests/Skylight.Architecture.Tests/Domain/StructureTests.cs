using Skylight.Domain.Common.Entities;
using System.Reflection;

namespace Skylight.Architecture.Tests.Domain;

public class StructureTests(ITestOutputHelper outputHelper)
{
	[Fact]
	public void Entities_ShouldNotHaveMutableCollectionsExposed()
	{
		IEnumerable<PropertyInfo> resultTypes = Types
			.InAssembly(Assemblies.Domain)
			.That()
			.Inherit(typeof(BaseEntity))
			.GetTypes()
			.SelectMany(t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance))
			.Where(p =>
				p.PropertyType.IsAssignableToGeneric(typeof(ICollection<>)));

		TestOutputHelpers.PrintFailingMembers(outputHelper, resultTypes);

		Assert.Empty(resultTypes);
	}
}
