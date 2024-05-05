using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <summary>
/// Represents the shared properties of all view models.
/// </summary>
public abstract record BaseModel
{
    public int? Id { get; init; }

    [Required]
    public required bool Deleted { get; init; }
}