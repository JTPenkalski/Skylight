using Skylight.Forms.Guides;
using Skylight.Models;

namespace Skylight.Forms.Directors
{
    /// <summary>
    /// Determines how the controls on a <see cref="Location"/> form should operate to ensure valid data.
    /// </summary>
    public interface ILocationFormDirector : IFormDirector<Location, LocationFormGuide> { }
}
