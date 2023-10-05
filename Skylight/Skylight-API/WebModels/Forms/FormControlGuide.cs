using Skylight.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.FormControlGuide{T}"/>
    public class FormControlGuide
    {
        [Required]
        public required FormControlValidation Validation { get; init; }

        [Required]
        public required bool ReadOnly { get; init; }

        [Required]
        public required bool Hidden { get; init; }

        [Required]
        public required object? DefaultValue { get; init; }

        [Required]
        public required IEnumerable<FormControlValue>? SuppliedValues { get; init; }
    }
}
