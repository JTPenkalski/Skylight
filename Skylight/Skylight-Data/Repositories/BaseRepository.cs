using Microsoft.EntityFrameworkCore;
using Skylight.Contexts;
using Skylight.Models;
using System;
using System.Collections.Generic;
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
        protected readonly DbSet<T> table;

        /// <summary>
        /// Constructs a new repository instance.
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(WeatherExperienceContext context)
        {
            table = context.Set<T>();
        }

        /// <inheritdoc cref="IRepository{T}.CreateAsync(T)"/>
        public virtual async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            await table.AddAsync(entity);
        }

        /// /// <inheritdoc cref="IRepository{T}.ReadAsync(int)"/>
        public virtual async Task<T?> ReadAsync(int id)
        {
            return await table.FindAsync(id);
        }

        /// <inheritdoc cref="IRepository{T}.ReadAllAsync"/>
        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await table.ToListAsync();
        }

        /// <inheritdoc cref="IRepository{T}.UpdateAsync(T)(T)"/>
        public virtual async Task UpdateAsync(T entity)
        {
            if (await table.FindAsync(entity.Id) is not null)
            {
                entity.UpdatedDate = DateTime.Now;

                table.Update(entity);
            }
        }

        /// <inheritdoc cref="IRepository{T}.DeleteAsync(int)(T)"/>
        public virtual async Task DeleteAsync(int id)
        {
            T? entity = await table.FindAsync(id);

            if (entity is not null)
            {
                entity.UpdatedDate = DateTime.Now;
                entity.Deleted = true;

                table.Update(entity);
            }
        }
    }
}