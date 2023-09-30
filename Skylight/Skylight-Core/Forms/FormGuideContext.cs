using System.Collections.Generic;

namespace Skylight.Forms
{
    /// <summary>
    /// Context data for <see cref="FormGuide"/> instances.
    /// These may contain data external to a <see cref="Models.BaseModel"/> that is necessary for guide evaluation.
    /// </summary>
    public class FormGuideContext
    {
        public required IReadOnlyDictionary<string, object> Attributes { get; set; }
    }
}
