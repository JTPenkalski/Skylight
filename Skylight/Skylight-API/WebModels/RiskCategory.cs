using System.Collections.Generic;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.RiskCategory"/>
    public record RiskCategory : BaseWebModel
    {
        public required string Code { get; init; }
        public required string Category { get; init; }
        public required string Details { get; init; }
        public required string Summary { get; init; }

        public virtual ICollection<RiskCategoryOutlookProbability> RiskProbabilities { get; init; } = new HashSet<RiskCategoryOutlookProbability>();
    }
}