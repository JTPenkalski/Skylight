using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <summary>
    /// Represents the shared properties of all view models.
    /// </summary>
    public abstract record BaseWebModel
    {
        [Required]
        public required int Id { get; init; }
    }
}