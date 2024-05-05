using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <inheritdoc cref="Domain.Entities.Location"/>
public record Location : BaseModel
{
    [Required]
    public required string City { get; init; }

    [Required]
    public required string Country { get; init; }
}