using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.Guides.LocationFormGuide"/>
    public class LocationFormGuide : FormGuide
    {
        [Required]
        public required FormControlGuide City { get; init; }

        [Required]
        public required FormControlGuide Country { get; init; }
    }
}
