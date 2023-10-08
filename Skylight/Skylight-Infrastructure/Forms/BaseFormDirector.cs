using Skylight.Models;
using Skylight.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Forms.Directors
{
    /// <summary>
    /// Represents the shared behavior of all form directors.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    /// <typeparam name="TModel">The type of entity this form represents. Must be a <see cref="BaseIdentifiableModel"/>.</typeparam>
    public abstract class BaseFormDirector<TModel, TFormGuide> : IFormDirector<TModel, TFormGuide>
        where TModel : BaseIdentifiableModel
        where TFormGuide : FormGuide
    {
        protected readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Constructs a new form director instance.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work service.</param>
        /// <param name="mapper">Mapper service.</param>
        public BaseFormDirector(
            IUnitOfWork unitOfWork
        )
        {
            this.unitOfWork = unitOfWork;
        }

        public abstract Task<TFormGuide> GetGuideAsync(TModel model, FormGuideContext context);

        /// <summary>
        /// Reads all values from an <see cref="IRepository{T}"/> to use for <see cref="FormControlGuide{T}.SuppliedValues"/>.
        /// </summary>
        /// <param name="repository">The <see cref="IRepository{T}"/> to query.</param>
        /// <param name="nameFunc">The function to use when determining each <see cref="FormControlValue{T}.Name"/>.</param>
        /// <returns>A collection of <see cref="FormControlValue{T}"/> instances.</returns>
        protected async Task<IEnumerable<FormControlValue<T>>> GetValuesFromRepository<T>(IRepository<T> repository, Func<T, string> nameFunc)
            where T : BaseModel
            => (await repository.ReadAllAsync()).Select(x => new FormControlValue<T>(nameFunc(x), x));

        /// <summary>
        /// Helper for creating a standardized format for accessing UI control names from a <see cref="BaseModel"/> property.
        /// </summary>
        /// <remarks>
        /// If the property is an object, pass in <c>nameof(RootPropertyType)</c> first, followed by <c>nameof(NestedPropertyName)</c>.
        /// </remarks>
        /// <param name="propertyNames">The <c>nameof()</c> values of a <see cref="BaseModel"/> property.</param>
        /// <returns>The name of the actual UI control.</returns>
        protected static string GetControlName(params string[] propertyNames) => string.Join('.', propertyNames).ToLower();

        /// <inheritdoc cref="GetControlName(string[])"/>
        /// <param name="index">The index of this control within some <see cref="IEnumerable{T}"/>.</param>
        protected static string GetControlName(int index, params string[] propertyNames) => $"{GetControlName(propertyNames)}-{index}";
    }
}