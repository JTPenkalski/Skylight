using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels.Models
{
    /// <inheritdoc cref="RiskCategoryOutlookProbability"/>
    public record RiskCategoryOutlookProbability : BaseWebModel
    {
        [Required]
        [Range(1, 3)]
        public required int Day { get; init; }

        [Required]
        [Range(0, 100)]
        public required int Chance { get; init; }

        [Required]
        public required bool SignificantSevere { get; init; }

        [Required]
        public required OutlookProbabilityWeatherType OutlookProbabilityWeatherType { get; init; }
    }
}