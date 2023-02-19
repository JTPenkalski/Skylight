using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.DatabaseContexts.Factories;
using Skylight.Models;
using Skylight.Repositories;
using System.Linq;

namespace Skylight.Services
{
    /// <summary>
    /// Represents the shared behavior of all database services.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    public abstract class BaseService
    {
        protected readonly ILogger logger;
        protected readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Constructs a new service instance.
        /// </summary>
        /// <param name="logger">Logging service.</param>
        /// <param name="unitOfWork">Unit of Work service.</param>
        public BaseService(
            ILogger logger,
            IUnitOfWork unitOfWork
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Checks the database context in the specified table for a certain entity.
        /// </summary>
        /// <typeparam name="T">The model type used in the specified table.</typeparam>
        /// <param name="table">The table to search in the database.</param>
        /// <param name="id">The ID of the target entity.</param>
        /// <returns>A boolean indicating if the entity is already stored or not.</returns>
        protected static bool EntityExists<T>(DbSet<T> table, int id) where T : class, IIdentifiable
        {
            return (table?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}