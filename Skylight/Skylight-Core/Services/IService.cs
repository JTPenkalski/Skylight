using Skylight.Communication;
using Skylight.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Services
{
    /// <summary>
    /// Manages business logic operations on data models.
    /// </summary>
    /// <typeparam name="T">The type of the model to operate on.</typeparam>
    public interface IService<T> where T : BaseIdentifiableModel
    {
        /// <summary>
        /// Adds a model of type <typeparamref name="T"/> to the database.
        /// </summary>
        /// <param name="model">The model to create.</param>
        /// <returns>A response object indicating the status of this operation, with the added model, or null if it was not added.</returns>
        Task<ServiceResponse<T>> AddAsync(T model);

        /// <summary>
        /// Gets a model of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <param name="id">The ID of the model to get.</param>
        /// <returns>A response object indicating the status of this operation, with the retrieved model, or null if it was not found.</returns>
        Task<ServiceResponse<T>> GetAsync(int id);

        /// <summary>
        /// Gets all models of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <returns>A response object indicating the status of this operation, with an <see cref="IEnumerable{T}"/> of the retrieved models.</returns>
        Task<ServiceResponse<IEnumerable<T>>> GetAllAsync();

        /// <summary>
        /// Modifies a model of type <typeparamref name="T"/> in the database.
        /// </summary>
        /// <param name="id">The ID of the model to modify.</param>
        /// <param name="model">The modified model.</param>
        /// <returns>A response object indicating the status of this operation, with the modified model.</returns>
        Task<ServiceResponse<T>> ModifyAsync(int id, T model);

        /// <summary>
        /// Removes a model of type <typeparamref name="T"/> from the database.
        /// </summary>
        /// <param name="id">The ID of the model to remove.</param>
        /// <returns>A response object indicating the status of this operation, with the removed model, or null if it was not found.</returns>
        Task<ServiceResponse<T>> RemoveAsync(int id);
    }
}