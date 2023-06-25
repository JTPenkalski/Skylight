using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.Location"/>
    public record Location : BaseWebModel
    {
        [Required]
        public required string City { get; init; }

        [Required]
        public required string ZipCode { get; init; }

        [Required]
        public required string Country { get; init; }
    }
}