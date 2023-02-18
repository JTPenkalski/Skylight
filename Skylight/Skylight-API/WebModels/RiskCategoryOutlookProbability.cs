using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.RiskCategoryOutlookProbability"/>
    public record RiskCategoryOutlookProbability : BaseWebModel
    {
        [Range(1, 3)] public required int Day { get; init; }
        [Range(0, 100)] public required int Chance { get; init; }
        public required bool SignificantSevere { get; init; }
        public required OutlookProbabilityWeatherType OutlookProbabilityWeatherType { get; init; }
        public required RiskCategory RiskCategory { get; init; }
    }
}