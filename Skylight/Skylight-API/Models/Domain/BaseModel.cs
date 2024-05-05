using System.ComponentModel.DataAnnotations;

namespace Skylight.Web.Models;

/// <summary>
/// Represents the shared properties of all Web models.
/// </summary>
public abstract record BaseModel
{
    [Required]
    public required Guid Id { get; init; }
}