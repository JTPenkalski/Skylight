using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.WeatherAlert"/>
public record WeatherAlert : BaseModel
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Description { get; init; }

    [Required]
    public required string Source { get; init; }

    [Required]
    public required float Severity { get; init; }
}