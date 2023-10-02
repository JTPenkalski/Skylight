using Skylight.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.FormControl{T}"/>
    public class FormControl<T>
    {
        [Required]
        public required FormControlValidation Validation { get; init; }

        [Required]
        public required bool ReadOnly { get; init; }

        [Required]
        public required bool Hidden { get; init; }

        [Required]
        public required T? DefaultValue { get; init; }

        [Required]
        public required IEnumerable<FormControlValue<T>>? SuppliedValues { get; init; }
    }
}
