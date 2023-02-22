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
        protected readonly ILogger logger;
        protected readonly IUnitOfWork unitOfWork;
        protected readonly IRepository<T> repository;

        /// <summary>
        /// Constructs a new service instance.
        /// </summary>
        /// <param name="logger">Logging service.</param>
        /// <param name="unitOfWork">Unit of Work service.</param>
        /// <param name="repository">Repository service.</param>
        public BaseService(
            ILogger logger,
            IUnitOfWork unitOfWork,
            IRepository<T> repository
        )
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
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

        /// <inheritdoc cref="IService{T}.AddAsync(T)"/>
        public virtual async Task<ServiceResponse<T>> AddAsync(T model)
        {
            bool success = true;

            try
            {
                await repository.CreateAsync(model);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<T>(success, model);
        }

        /// <inheritdoc cref="IService{T}.GetAsync(int)"/>
        public virtual async Task<ServiceResponse<T>> GetAsync(int id)
        {
            T? model = await repository.ReadAsync(id);

            return new ServiceResponse<T>(model is not null, model);
        }

        /// <inheritdoc cref="IService{T}.GetAsync"/>
        public virtual async Task<ServiceResponse<IEnumerable<T>>> GetAllAsync()
        {
            IEnumerable<T> models = await repository.ReadAllAsync();

            return new ServiceResponse<IEnumerable<T>>(models.Any(), models);
        }

        /// <inheritdoc cref="IService{T}.ModifyAsync(int, T)"/>
        public virtual async Task<ServiceResponse<T>> ModifyAsync(int id, T model)
        {
            bool success = await repository.ReadAsync(id) is not null;

            try
            {
                if (success)
                {
                    await repository.UpdateAsync(model);
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

        /// <inheritdoc cref="IService{T}.RemoveAsync(int)"/>
        public virtual async Task<ServiceResponse<T>> RemoveAsync(int id)
        {
            T? model = await repository.ReadAsync(id);
            bool success = model is not null;

            try
            {
                if (success)
                {
                    await repository.DeleteAsync(id);
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
    }
}