using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Skylight.Models
{
    public class RiskCategory
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string Summary { get; set; }
        public ICollection<RiskCategoryOutlookProbability> TornadoRisk { get; set; }
        public ICollection<RiskCategoryOutlookProbability> WindRisk { get; set; }
        public ICollection<RiskCategoryOutlookProbability> HailRisk { get; set; }

        public RiskCategory(
            int id,
            string code,
            string category,
            string details,
            string summary
        ) : this(id, code, category, details, summary, new List<RiskCategoryOutlookProbability>(), new List<RiskCategoryOutlookProbability>(), new List<RiskCategoryOutlookProbability>()) { }

        public RiskCategory(
            int id, 
            string code, 
            string category, 
            string details, 
            string summary, 
            ICollection<RiskCategoryOutlookProbability> tornadoRisk, 
            ICollection<RiskCategoryOutlookProbability> windRisk,
            ICollection<RiskCategoryOutlookProbability> hailRisk
        )
        {
            Id = id;
            Code = code;
            Category = category;
            Details = details;
            Summary = summary;
            TornadoRisk = tornadoRisk;
            WindRisk = windRisk;
            HailRisk = hailRisk;
        }
    }

    [Owned]
    public class RiskCategoryOutlookProbability
    {
        private static ICollection<RiskCategoryOutlookProbability> _unused = new List<RiskCategoryOutlookProbability> { new(0f, false) };
        public static ICollection<RiskCategoryOutlookProbability> Unused => _unused;

        public float Chance { get; init; }
        public bool SignificantSevere { get; init; }

        public RiskCategoryOutlookProbability(float chance, bool significantSevere)
        {
            Chance = chance;
            SignificantSevere = significantSevere;
        }

        public static ICollection<RiskCategoryOutlookProbability> Build(params (float chance, bool sigSevere)[] probabilities)
        {
            return (probabilities is null || probabilities.Length == 0)
                ? Unused
                : new List<RiskCategoryOutlookProbability>(probabilities.Select(p => new RiskCategoryOutlookProbability(p.chance, p.sigSevere)));
        }
    }
}