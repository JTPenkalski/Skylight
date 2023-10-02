using Skylight.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// TODO: Investigate creating a custom AutoMapper converter to make this non-generic and use object instead on the API.
//       This will prevent the API schema from getting bloated with type-specific controls that the UI probably doesn't need to care about.

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
