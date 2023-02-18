using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.DatabaseContexts.Factories;
using Skylight.Models;
using System.Linq;

namespace Skylight.Services
{
    /// <summary>
    /// Represents the shared behavior of all database services.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    public class BaseService
    {
        protected readonly ILogger logger;
        protected readonly IWeatherExperienceContextFactory contextFactory;

        /// <summary>
        /// Constructs a new service instance.
        /// </summary>
        /// <param name="contextFactory">Database context creator.</param>
        public BaseService(
            ILogger logger,
            IWeatherExperienceContextFactory contextFactory
        )
        {
            this.logger = logger;
            this.contextFactory = contextFactory;
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