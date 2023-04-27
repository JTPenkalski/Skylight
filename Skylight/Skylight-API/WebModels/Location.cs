using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.Location"/>
    [JsonSerializable(typeof(Location))]
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