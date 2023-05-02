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

            try
            {
                Repository.Attach(model);
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
            bool success = true;

            try
            {
                await Repository.Update(model);
                await Console.Out.WriteLineAsync(unitOfWork.ChangeTrackingStatus);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<T>(success, null);
        }

        public virtual async Task<ServiceResponse<T>> RemoveAsync(int id)
        {
            bool success = true;

            try
            {
                await Repository.Delete(id);
                await Console.Out.WriteLineAsync(unitOfWork.ChangeTrackingStatus);
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<T>(success, null);
        }
    }
}