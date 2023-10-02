using System.ComponentModel.DataAnnotations;
using Skylight.WebModels.Models;

namespace Skylight.WebModels.Forms
{
    /// <summary>
    /// Encapsulates the needed data for a request to obtain a <see cref="Forms.FormGuide"/>.
    /// </summary>
    public class FormGuideRequest<T> where T : BaseWebModel
    {
        [Required]
        public required T Model { get; init; }

        [Required]
        public required FormGuideContext Context { get; init; }
    }
}
