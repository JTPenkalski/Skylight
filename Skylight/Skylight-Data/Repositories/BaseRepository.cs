using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Contexts;
using Skylight.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Represents the shared behavior of all database repositories. Uses Entity Framework Core as the implementation.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository is accessing. Must be a <see cref="BaseIdentifiableModel"/>.</typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseIdentifiableModel
    {
        protected readonly ILogger logger;
        protected readonly DbSet<T> table;

        /// <summary>
        /// Constructs a new repository instance.
        /// </summary>
        /// <param name="logger">Logging service.</param>
        /// <param name="context">EF Core Database Context service.</param>
        public BaseRepository(
            ILogger<BaseRepository<T>> logger,
            WeatherExperienceContext context
        )
        {
            this.logger = logger;
            table = context.Set<T>();
        }

        public virtual int Create(T entity)
        {
            logger.LogInformation(
                "Creating entity of type {TYPE_NAME} in the database.",
                typeof(T).Name
            );

            return table.Attach(entity).Entity.Id;
        }

        public virtual async Task<T?> ReadAsync(int id)
        {
            logger.LogInformation(
                "Reading entity of type {TYPE_NAME} with ID = {ID} from the database.",
                typeof(T).Name,
                id
            );

            return await table.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            logger.LogInformation(
                "Reading all entities of type {TYPE_NAME} from the database.",
                typeof(T).Name
            );

            return (await table.ToListAsync()).Where(e => !e.Deleted);
        }

        public virtual bool Update(T entity)
        {
            logger.LogInformation(
                "Updating entity of type {TYPE_NAME} with ID = {ID} in the database.",
                typeof(T).Name,
                entity.Id
            );

            return table.Update(entity) is not null;
        }

        public virtual async Task<bool> Delete(int id)
        {
            logger.LogInformation(
                "Hard deleting entity of type {TYPE_NAME} with ID = {ID} from the database.",
                typeof(T).Name,
                id
            );

            T? existing = await ReadAsync(id);
            bool success = false;

            if (existing is not null)
            {
                success = true;

                table.Remove(existing);
            }

            return success;
        }
    }
}