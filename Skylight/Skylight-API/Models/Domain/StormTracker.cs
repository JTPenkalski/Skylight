using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.StormTracker"/>
public record StormTracker : BaseModel
{
    [Required]
    public required string FirstName { get; init; }

    [Required]
    public required string LastName { get; init; }

    [Required]
    public required DateTimeOffset StartDate { get; init; }

    public string? Biography { get; init; }
}