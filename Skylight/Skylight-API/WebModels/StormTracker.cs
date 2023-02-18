using System;

namespace Skylight.WebModels
{
    /// <inheritdoc cref="Models.StormTracker"/>
    public record StormTracker : BaseWebModel
    {
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string? Biography { get; init; }
        public required DateTime StartDate { get; init; }
        public required string? PicturePath { get; init; }
    }
}