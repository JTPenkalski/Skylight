using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.WeatherIncident"/>
public record WeatherIncident : BaseModel
{
    [Required]
    public required string Name { get; init; }

    [Required]
    public required string Description { get; init; }

    [Required]
    public required DateTimeOffset StartDate { get; init; }

    public DateTimeOffset? EndDate { get; init; }
}
