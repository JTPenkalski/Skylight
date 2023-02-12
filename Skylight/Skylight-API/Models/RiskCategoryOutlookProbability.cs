using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.Models
{
    /// <summary>
    /// Represents an individual probability used to determine which <see cref="RiskCategory"/> should be assigned to an SPC outlook forecast on a given day.
    /// </summary>
    [Owned]
    public class RiskCategoryOutlookProbability
    {
        public const int MIN_DAY = 1;
        public const int MAX_DAY = 3;

        [Key] public int Id { get; private set; }
        public int Day { get; set; }
        public int Chance { get; set; }
        public bool SignificantSevere { get; set; }
        public OutlookProbabilityWeatherType OutlookProbabilityWeatherType { get; set; }
        public RiskCategory RiskCategory { get; set; } = null!;

        public RiskCategoryOutlookProbability() : this(OutlookProbabilityWeatherType.Combined, 1, 0, false) { }

        /// <summary>
        /// Constructs a new <see cref="RiskCategoryOutlookProbability"/> instance.
        /// </summary>
        /// <param name="type">The type of weather this probability is for.</param>
        /// <param name="day">The day the outlook would be released on. Supports the range [1-3].</param>
        /// <param name="chance">The probability required for the Risk Category to be assigned. Supports the range [0-100].</param>
        /// <param name="significantSevere">If the probability includes a significant severe indicator.</param>
        public RiskCategoryOutlookProbability(OutlookProbabilityWeatherType type, int day, int chance, bool significantSevere)
        {
            Day = Math.Clamp(day, MIN_DAY, MAX_DAY);
            Chance = Math.Clamp(chance, 0, 100);
            SignificantSevere = significantSevere;
            OutlookProbabilityWeatherType = type;
        }

        /// <summary>
        /// Instantiates a new <see cref="RiskCategoryOutlookProbability"/> collection for the same type and day, for all given probabilities.
        /// It is more convenient than individually instantiating them in a collection initializer.
        /// </summary>
        /// <param name="type">The <see cref="Models.OutlookProbabilityWeatherType"/> to use for this collection.</param>
        /// <param name="day">The day to use for this collection.</param>
        /// <param name="probabilities">The list of probabilities to use, in tuple form.</param>
        /// <returns>An <see cref="ICollection{T}"/> of Outlook Probabilities.</returns>
        public static ICollection<RiskCategoryOutlookProbability> Build(OutlookProbabilityWeatherType type, int day, params (int chance, bool sigSevere)[] probabilities)
        {
            return probabilities.Select(p => new RiskCategoryOutlookProbability(type, day, p.chance, p.sigSevere)).ToList();
        }

        /// <summary>
        /// Instantiates a single, new <see cref="RiskCategoryOutlookProbability"/> collection that contains each element from every supplied collection.
        /// It is more convenient than manually instantiating them in a collection initializer.
        /// </summary>
        /// <param name="probabilities"></param>
        /// <returns>An <see cref="ICollection{T}"/> of Outlook Probabilities.</returns>
        public static ICollection<RiskCategoryOutlookProbability> Merge(params ICollection<RiskCategoryOutlookProbability>[] probabilities)
        {
            return probabilities.SelectMany(p => p).ToList();
        }
    }
}