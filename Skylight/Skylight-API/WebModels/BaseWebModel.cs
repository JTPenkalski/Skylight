namespace Skylight.WebModels
{
    /// <summary>
    /// Represents the shared properties of all view models.
    /// </summary>
    public abstract record BaseWebModel
    {
        public int Id { get; init; }
    }
}