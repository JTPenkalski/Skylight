using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.WeatherEvent"/>
public record WeatherEvent : BaseModel
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required DateTime StartDate { get; init; }

    [Required]
    public required Weather Weather { get; init; }

    public string? Description { get; init; }

    public DateTime? EndDate { get; init; }
}