using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.Weather"/>
public record Weather : BaseModel
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Description { get; init; }
}