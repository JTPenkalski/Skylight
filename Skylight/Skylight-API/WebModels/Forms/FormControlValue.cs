using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.FormControlValue{T}"/>
    public class FormControlValue
    {
        [Required]
        public required string Name { get; init; }

        [Required]
        public required object Value { get; init; }
    }
}
