namespace Skylight.Models
{
    /// <summary>
    /// Represents an item with a unique ID in the database.
    /// </summary>
    public interface IIdentifiable
    {
        int Id { get; }
    }
}