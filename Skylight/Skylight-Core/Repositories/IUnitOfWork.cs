using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Provides transaction management services when performing database operations.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all current changes to the database.
        /// Either all changes are applied, or none of them are.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Saves all current changes to the database before closing the connection.
        /// Either all changes are applied, or none of them are. Disposes the resource regardless.
        /// </summary>
        Task CommitAndCloseAsync();

        /// <summary>
        /// Disposes the current database, effectively cancelling all current changes.
        /// </summary>
        Task RollbackAsync();
    }
}