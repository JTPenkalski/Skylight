using System;

namespace Skylight.Models
{
    /// <summary>
    /// Represents the shared properties of all tables in the database.
    /// Primarily used for ensuring tracking columns exist.
    /// Allows subclasses to use custom primary keys, such as composite keys.
    /// Use <see cref="BaseIdentifiableModel"/> for establishing a primary key "Id" column.
    /// </summary>
    public abstract class BaseModel
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
