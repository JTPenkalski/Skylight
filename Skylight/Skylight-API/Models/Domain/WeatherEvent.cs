using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.WeatherEvent"/>
public record WeatherEvent : BaseModel
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Description { get; init; }

    [Required]
    public required DateTimeOffset StartDate { get; init; }

    [Required]
    public required Weather Weather { get; init; }

    [Required]
    public required IEnumerable<WeatherIncident> Incidents { get; init; }

    public DateTimeOffset? EndDate { get; init; }
}