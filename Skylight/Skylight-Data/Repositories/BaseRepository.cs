using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Skylight.Contexts;
using Skylight.Models;
using System;
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
        protected readonly DbSet<T> table;

        /// <summary>
        /// Constructs a new repository instance.
        /// </summary>
        /// <param name="mapper">Mapping service.</param>
        /// <param name="context">EF Core Database Context service.</param>
        public BaseRepository(WeatherExperienceContext context)
        {
            table = context.Set<T>();
        }

        public virtual void Attach(T entity)
        {
            if (entity.Id == 0)
            {
                entity.CreatedDate = DateTime.Now;
            }

            entity.UpdatedDate = DateTime.Now;

            table.Attach(entity);
        }

        public virtual int Create(T entity)
        {
            entity.CreatedDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;

            return table.Add(entity).Entity.Id;
        }

        public virtual async Task<T?> ReadAsync(int id)
        {
            return await table.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> ReadAllAsync()
        {
            return (await table.ToListAsync()).Where(e => !e.Deleted);
        }

        public virtual async Task<bool> Update(T entity)
        {
            T? existing = await ReadAsync(entity.Id);
            bool success = false;

            if (existing is not null)
            {
                success = true;

                entity.UpdatedDate = DateTime.Now;

                table.Entry(existing).CurrentValues.SetValues(entity);
            }

            return success;
        }

        public virtual async Task<bool> Delete(T entity)
        {
            entity.Deleted = true;

            return await Update(entity);
        }

        /// <summary>
        /// Automatically 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="currentItems"></param>
        /// <param name="newItems"></param>
        /// <param name="keyFunc"></param>
        protected void UpdateCollection<TEntity>(DbContext context, ICollection<TEntity> currentItems, ICollection<TEntity> newItems, Func<TEntity, int> keyFunc) where TEntity : BaseIdentifiableModel
        {
            // Loop through all items in the existing collection
            // If the new collection does not have an item, remove it from the existing collection, otherwise update it
            var toRemove = new List<TEntity>();
            foreach (TEntity item in currentItems)
            {
                TEntity? found = newItems.FirstOrDefault(x => keyFunc(item)!.Equals(keyFunc(x)));

                if (found is null)
                {
                    toRemove.Add(item);
                }
                else if (!ReferenceEquals(found, item))
                {
                    context.Entry(item).CurrentValues.SetValues(found);
                }
            }

            if (toRemove.Any())
            {
                toRemove.ForEach(x => currentItems.Remove(x));
            }

            // Loop through all items in the new collection
            // If the existing collection does not have an item, add it to the existing collection
            foreach (TEntity newItem in newItems)
            {
                TEntity? found = currentItems.FirstOrDefault(x => keyFunc(newItem)!.Equals(keyFunc(x)));

                if (found is null)
                {
                    currentItems.Add(newItem);
                }
            }
        }
    }
}