using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Communication;
using Skylight.Models;
using Skylight.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Services
{
    /// <summary>
    /// Represents the shared behavior of all database services.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    /// <typeparam name="T">The type of entity this service is operating on. Must be a <see cref="BaseIdentifiableModel"/>.</typeparam>
    public abstract class BaseService<T> : IService<T> where T : BaseIdentifiableModel
    {
        protected const string NULL_MSG = "{0} cannot be null.";

        protected readonly ILogger logger;
        protected readonly IUnitOfWork unitOfWork;

        protected abstract IRepository<T> Repository { get; }

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

        public virtual async Task<ServiceResponse<T>> AddAsync(T model)
        {
            bool success = true;

            await Console.Out.WriteLineAsync("\n\nBEFORE:");
            await Console.Out.WriteLineAsync(unitOfWork.ChangeTrackingStatus);

            try
            {
                Repository.Attach(model);
                await Console.Out.WriteLineAsync("\n\nAFTER CREATE:");
                await Console.Out.WriteLineAsync(unitOfWork.ChangeTrackingStatus);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<T>(success, model);
        }

        public virtual async Task<ServiceResponse<T>> GetAsync(int id)
        {
            T? model = await Repository.ReadAsync(id);

            return new ServiceResponse<T>(model is not null, model);
        }

        public virtual async Task<ServiceResponse<IEnumerable<T>>> GetAllAsync()
        {
            IEnumerable<T> models = await Repository.ReadAllAsync();

            return new ServiceResponse<IEnumerable<T>>(models.Any(), models);
        }

        public virtual async Task<ServiceResponse<T>> ModifyAsync(int id, T model)
        {
            bool success = await Repository.ReadAsync(id) is not null;

            try
            {
                if (success)
                {
                    await Repository.UpdateAsync(model);
                    await unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<T>(success, model);
        }

        public virtual async Task<ServiceResponse<T>> RemoveAsync(int id)
        {
            T? model = await Repository.ReadAsync(id);
            bool success = model is not null;

            try
            {
                if (success)
                {
                    await Repository.DeleteAsync(id);
                    await unitOfWork.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<T>(success, model);
        }

        /// <summary>
        /// Checks the database context in the specified table for a certain entity.
        /// </summary>
        /// <param name="table">The table to search in the database.</param>
        /// <param name="id">The ID of the target entity.</param>
        /// <returns>A boolean indicating if the entity is already stored or not.</returns>
        protected bool EntityExists(DbSet<T> table, int id)
        {
            return (table?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        /// <summary>
        /// Sets up a navigation property for tracking. It will attempt to locate the entity in the database,
        /// if it is found, it will use that entity, otherwise, the original will be used.
        /// This prevents errors that arise when trying to add the same, untracked entity twice.
        /// </summary>
        /// <typeparam name="TModel">The type of the web model to get.</typeparam>
        /// <param name="entity">The entity to get.</param>
        /// <param name="repository">The repository to use from an <see cref="IUnitOfWork"/>.</param>
        /// <returns>The entity to use, either the existing, tracked version, or the new, original version.</returns>
        protected async Task<TModel> InitProperty<TModel>(TModel entity, IRepository<TModel> repository) where TModel : BaseIdentifiableModel
        {
            return (await repository.ReadAsync(entity.Id)) ?? entity;
        }

        /// <summary>
        /// Sets up a navigation property collection for tracking. It will attempt to locate its entities in the database,
        /// if one is found, it will use that entity, otherwise, the original will be used.
        /// This prevents errors that arise when trying to add the same, untracked entity twice.
        /// </summary>
        /// <typeparam name="TModel">The type of the web model to get.</typeparam>
        /// <param name="entities">The entities to get.</param>
        /// <param name="repository">The repository to use from an <see cref="IUnitOfWork"/>.</param>
        /// <returns>A collection with the entities to use, either the existing, tracked versions, or the new, original versions.</returns>
        protected async Task<IEnumerable<TModel>> InitProperty<TModel>(IEnumerable<TModel> entities, IRepository<TModel> repository) where TModel : BaseIdentifiableModel
        {
            return await Task.WhenAll(entities.Select(e => InitProperty(e, repository)));
        }
    }
}