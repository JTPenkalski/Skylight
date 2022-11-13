using System.Collections.Generic;

namespace Skylight.Models
{
    public class RiskCategory
    {
        public int Id { get; private set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string Summary { get; set; }
        public ICollection<RiskCategoryOutlookProbability> RiskProbabilities { get; set; }

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