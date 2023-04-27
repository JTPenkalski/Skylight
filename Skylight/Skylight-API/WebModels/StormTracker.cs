using System;
using System.ComponentModel.DataAnnotations;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.StormTracker"/>
    public record StormTracker : BaseWebModel
    {
        [Required]
        public required string FirstName { get; init; }

        [Required]
        public required string LastName { get; init; }

        [Required]
        public required DateTime StartDate { get; init; }

        public string? Biography { get; init; }

        public string? PicturePath { get; init; }
    }
}