using Microsoft.EntityFrameworkCore;
using Skylight.Contexts;
using Skylight.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <summary>
    /// Base repository implementation that uses Entity Framework Core for data operations.
    /// </summary>
    /// <typeparam name="T">The type of entity this repository is accessing. Must be a <see cref="BaseIdentifiableModel"/>.</typeparam>
    public class BaseRepository<T> : IRepository<T> where T : BaseIdentifiableModel
    {
        protected readonly DbSet<T> table;

        public BaseRepository(WeatherExperienceContext context)
        {
            table = context.Set<T>();
        }

        public virtual async Task CreateAsync(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            await table.AddAsync(entity);
        }

        public virtual async Task<T?> ReadAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await table.ToListAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (await table.FindAsync(entity.Id) is not null)
            {
                entity.UpdatedDate = DateTime.Now;

                table.Update(entity);
            }
        }

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