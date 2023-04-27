using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.RiskCategory"/>
    public record RiskCategory : BaseWebModel
    {
        [Required]
        public required string Code { get; init; }

        [Required]
        public required string Category { get; init; }

        [Required]
        public required string Details { get; init; }

        [Required]
        public required string Summary { get; init; }

        [Required]    
        public required IEnumerable<RiskCategoryOutlookProbability> RiskProbabilities { get; init; }
    }
}