namespace Skylight.WebModels
{
    /// <summary>
    /// Represents the shared properties of all view models.
    /// </summary>
    public abstract record BaseWebModel
    {
        public required int Id { get; init; }
    }
}