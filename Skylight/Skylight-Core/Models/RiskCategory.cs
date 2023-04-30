using System.Collections.Generic;

namespace Skylight.Models
{
    /// <summary>
    /// Represents a specific SPC outlook risk type.
    /// These are the colored areas that identify distinct regions of interest with differing probabilities.
    /// </summary>
    public class RiskCategory : BaseIdentifiableModel
    {
        public string Code { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<RiskCategoryOutlookProbability> RiskProbabilities { get; set; }

        /// <summary>
        /// Constructs a new <see cref="RiskCategory"/> instance.
        /// </summary>
        /// <param name="code">The 3-4 letter abbreviation used to represent this risk type.</param>
        /// <param name="category">The full name used to represent this risk type.</param>
        /// <param name="details">Official details describing this risk type.</param>
        /// <param name="summary">Official summary describing this risk type.</param>
        public RiskCategory(string code, string category, string details, string summary) :
            this(code, category, details, summary, new List<RiskCategoryOutlookProbability>()) { }

        /// <summary>
        /// Constructs a new <see cref="RiskCategory"/> instance.
        /// </summary>
        /// <param name="code">The 3-4 letter abbreviation used to represent this risk type.</param>
        /// <param name="category">The full name used to represent this risk type.</param>
        /// <param name="details">Official details describing this risk type.</param>
        /// <param name="summary">Official summary describing this risk type.</param>
        /// <param name="riskProbabilities">A collection of probabilities that define why this risk type is warranted.</param>
        public RiskCategory(string code, string category, string details, string summary, ICollection<RiskCategoryOutlookProbability> riskProbabilities)
        {
            Code = code;
            Category = category;
            Details = details;
            Summary = summary;
            RiskProbabilities = riskProbabilities;
        }
    }
}