using Skylight.Domain.Entities;
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
}
