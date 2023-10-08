using Skylight.Forms;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Forms
{
    /// <inheritdoc cref="Skylight.Forms.FormGuideContext"/>
    public class FormGuideContext
    {
        [Required]
        public required IReadOnlyDictionary<FormGuideContextKey, object> Attributes { get; init; }
    }
}
