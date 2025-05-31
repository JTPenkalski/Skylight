using Skylight.Domain.Common.Events;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Skylight.Application.Common.Events;

/// <summary>
/// Custom JSON contract to support polymorphic deserialization of <see cref="DomainEvent"/> types.
/// </summary>
public class DomainEventJsonTypeResolver : DefaultJsonTypeInfoResolver
{
	private static readonly IList<JsonDerivedType> DomainEventTypes =
		[
			.. typeof(DomainEvent).Assembly.GetTypes()
					.Where(x =>
						!x.IsAbstract
						&& x.IsAssignableTo(typeof(DomainEvent)))
					.Select(x => new JsonDerivedType(x, x.Name))
		];

	public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
	{
		JsonTypeInfo jsonTypeInfo = base.GetTypeInfo(type, options);

		if (jsonTypeInfo.Type == typeof(DomainEvent))
		{
			jsonTypeInfo.PolymorphismOptions = new JsonPolymorphismOptions
			{
				TypeDiscriminatorPropertyName = "$type",
				IgnoreUnrecognizedTypeDiscriminators = true,
				UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization,
			};

			foreach (JsonDerivedType derivedType in DomainEventTypes)
			{
				jsonTypeInfo.PolymorphismOptions.DerivedTypes.Add(derivedType);
			}
		}

		return jsonTypeInfo;
	}
}
