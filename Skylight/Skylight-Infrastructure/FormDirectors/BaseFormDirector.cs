using Skylight.Models;
using Skylight.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Forms
{
    /// <summary>
    /// Represents the shared behavior of all form directors.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    /// <typeparam name="T">The type of entity this form represents. Must be a <see cref="BaseIdentifiableModel"/>.</typeparam>
    public abstract class BaseFormDirector<T> : IFormDirector<T> where T : BaseIdentifiableModel
    {
        protected readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Constructs a new form director instance.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work service.</param>
        public BaseFormDirector(
            IUnitOfWork unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
        }

        public abstract Task<IEnumerable<FormGuide>> GetGuide(T model);
    }
}