using Skylight.Domain.Entities;
using Skylight.Domain.Extensions;
using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Skylight.Tests.Architecture.Domain;

public class StructureTests(ITestOutputHelper outputHelper)
{
    [Fact]
    public void Entities_ShouldNot_HaveNonVirtualCollectionProperties()
    {
        IEnumerable<PropertyInfo> resultTypes = Types
            .InAssembly(Assemblies.Domain)
            .That()
            .Inherit(typeof(BaseEntity))
            .GetTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p =>
                p.PropertyType.IsAssignableTo(typeof(IEnumerable))
                && !p.PropertyType.IsAssignableTo(typeof(string))
                && (!p.GetMethod?.IsVirtual ?? false)
                && !Attribute.IsDefined(p, typeof(NotMappedAttribute)));

        TestOutputHelpers.PrintFailingMembers(outputHelper, resultTypes);

        Assert.Empty(resultTypes);
    }

	[Fact]
	public void Entities_ShouldNot_HaveMutableCollectionsExposed()
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
