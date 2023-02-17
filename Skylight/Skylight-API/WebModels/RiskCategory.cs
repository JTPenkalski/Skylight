using System.Collections.Generic;

namespace Skylight.WebModels
{
    public class RiskCategory
    {
        public string Code { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string Summary { get; set; }

        public virtual ICollection<RiskCategoryOutlookProbability> RiskProbabilities { get; set; }

        public RiskCategory(
            string code,
            string category,
            string details,
            string summary
        ) : this(code, category, details, summary, new List<RiskCategoryOutlookProbability>()) { }

        public RiskCategory(
            string code, 
            string category, 
            string details, 
            string summary,
            ICollection<RiskCategoryOutlookProbability> riskProbabilities
        )
        {
            Code = code;
            Category = category;
            Details = details;
            Summary = summary;
            RiskProbabilities = riskProbabilities;
        }
    }
}