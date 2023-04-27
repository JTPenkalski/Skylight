using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.Weather"/>
    public record Weather : BaseWebModel
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required string Description { get; init; }
    }
}