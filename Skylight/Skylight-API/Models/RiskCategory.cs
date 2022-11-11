using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Skylight.Models
{
    public class RiskCategory
    {
        public int Id { get; private set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string Details { get; set; }
        public string Summary { get; set; }
        public RiskCategoryOutlookProbabilityTables RiskProbabilities { get; set; }

        public RiskCategory(
            string code,
            string category,
            string details,
            string summary
        ) : this(code, category, details, summary, new()) { }

        public RiskCategory(
            string code, 
            string category, 
            string details, 
            string summary,
            RiskCategoryOutlookProbabilityTables riskProbabilities
        )
        {
            Code = code;
            Category = category;
            Details = details;
            Summary = summary;
            RiskProbabilities = riskProbabilities;
        }
    }

    [Owned]
    public class RiskCategoryOutlookProbabilityTables
    {
        public RiskCategoryOutlookProbabilityTable DayOne { get; init; }
        public RiskCategoryOutlookProbabilityTable DayTwo { get; init; }
        public RiskCategoryOutlookProbabilityTable DayThree { get; init; }
        public RiskCategory RiskCategory { get; init; } = null!;

        public RiskCategoryOutlookProbabilityTables() : this(new(), new(), new()) { }

        public RiskCategoryOutlookProbabilityTables(
            RiskCategoryOutlookProbabilityTable dayOne,
            RiskCategoryOutlookProbabilityTable dayTwo,
            RiskCategoryOutlookProbabilityTable dayThree
        )
        {
            DayOne = dayOne;
            DayTwo = dayTwo;
            DayThree = dayThree;
        }
    }

    [Owned]
    public class RiskCategoryOutlookProbabilityTable
    {
        public ICollection<RiskCategoryOutlookProbability> TornadoRisk { get; init; }
        public ICollection<RiskCategoryOutlookProbability> WindRisk { get; init; }
        public ICollection<RiskCategoryOutlookProbability> HailRisk { get; init; }
        public RiskCategoryOutlookProbabilityTables ProbabilityTables { get; init; } = null!;

        public RiskCategoryOutlookProbabilityTable() : this(RiskCategoryOutlookProbability.Unused, RiskCategoryOutlookProbability.Unused, RiskCategoryOutlookProbability.Unused) { }

        public RiskCategoryOutlookProbabilityTable(
            ICollection<RiskCategoryOutlookProbability> tornadoRisk,
            ICollection<RiskCategoryOutlookProbability> windRisk,
            ICollection<RiskCategoryOutlookProbability> hailRisk
        )
        {
            TornadoRisk = tornadoRisk;
            WindRisk = windRisk;
            HailRisk = hailRisk;
        }
    }

    [Owned]
    public class RiskCategoryOutlookProbability
    {
        private static readonly ICollection<RiskCategoryOutlookProbability> _unused = new List<RiskCategoryOutlookProbability> { new(0, false) };
        public static ICollection<RiskCategoryOutlookProbability> Unused => _unused;

        [Key] public int Id { get; init; }
        public int Chance { get; init; }
        public bool SignificantSevere { get; init; }
        [ForeignKey("RiskCategoryId")] public RiskCategory RiskCategory { get; init; } = null!;

        public RiskCategoryOutlookProbability(int chance, bool significantSevere)
        {
            Chance = Math.Clamp(chance, 0, 100);
            SignificantSevere = significantSevere;
        }

        public static ICollection<RiskCategoryOutlookProbability> Build(params (int chance, bool sigSevere)[] probabilities)
        {
            return probabilities.Any()
                ? new List<RiskCategoryOutlookProbability>(probabilities.Select(p => new RiskCategoryOutlookProbability(p.chance, p.sigSevere)))
                : Unused;
        }
    }
}