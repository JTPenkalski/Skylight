using Microsoft.EntityFrameworkCore.Storage;
using Skylight.Models;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Provides transaction management services when performing database operations.
    /// </summary>
    public interface IUnitOfWork
    {
        IWeatherRepository Weather { get; }

        /// <summary>
        /// Saves all changes in the current transaction.
        /// Either all changes are applied, or none of them are.
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Cancels all changes in the current transaction.
        /// </summary>
        Task RollbackAsync();
    }
}