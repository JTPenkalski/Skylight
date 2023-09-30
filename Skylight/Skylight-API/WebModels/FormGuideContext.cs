using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Forms.FormGuideContext"/>
    public class FormGuideContext
    {
        [Required]
        public required IReadOnlyDictionary<string, object> Attributes { get; set; }
    }
}
