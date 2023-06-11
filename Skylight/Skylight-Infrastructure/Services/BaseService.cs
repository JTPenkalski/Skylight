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
            Repository.Create(model);
            bool success = await unitOfWork.CommitAsync();

            return new ServiceResponse<T>(success, model);
        }

        public virtual async Task<ServiceResponse<T>> GetAsync(int id)
        {
            T? model = await Repository.ReadAsync(id);
            bool success = model is not null;

            return new ServiceResponse<T>(success, model);
        }

        public virtual async Task<ServiceResponse<IEnumerable<T>>> GetAllAsync()
        {
            IEnumerable<T> models = await Repository.ReadAllAsync();
            bool success = models.Any();

            return new ServiceResponse<IEnumerable<T>>(success, models);
        }

        public virtual async Task<ServiceResponse<T>> ModifyAsync(int id, T model)
        {
            bool success = Repository.Update(model) && await unitOfWork.CommitAsync();

            return new ServiceResponse<T>(success);
        }

        public virtual async Task<ServiceResponse<T>> RemoveAsync(int id)
        {
            bool success = await Repository.Delete(id) && await unitOfWork.CommitAsync();

            return new ServiceResponse<T>(success);
        }
    }
}