namespace Skylight.Models
{
    /// <summary>
    /// Represents the shared properties of all tables in the database.
    /// Implements <see cref="IIdentifiable"/> to give all subclasses an ID.
    /// Primarily used for ensuring an ID and tracking columns exist.
    /// </summary>
    public abstract class BaseIdentifiableModel : BaseModel, IIdentifiable
    {
        public int Id { get; set; }
    }
}
