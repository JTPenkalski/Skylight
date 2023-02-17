using System;

namespace Skylight.WebModels
{
    public class RiskCategoryOutlookProbability
    {
        public const int MIN_DAY = 1;
        public const int MAX_DAY = 3;

        public int Day { get; set; }
        public int Chance { get; set; }
        public bool SignificantSevere { get; set; }
        public OutlookProbabilityWeatherType OutlookProbabilityWeatherType { get; set; }
        public RiskCategory RiskCategory { get; set; } = null!;

        public RiskCategoryOutlookProbability(OutlookProbabilityWeatherType type, int day, int chance, bool significantSevere)
        {
            Day = Math.Clamp(day, MIN_DAY, MAX_DAY);
            Chance = Math.Clamp(chance, 0, 100);
            SignificantSevere = significantSevere;
            OutlookProbabilityWeatherType = type;
        }
    }
}