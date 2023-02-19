using Skylight.DatabaseContexts;
using Skylight.DatabaseContexts.Factories;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IUnitOfWork"/>
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IWeatherExperienceContextFactory contextFactory;

        /// <summary>
        /// Creates a new <see cref="UnitOfWork"/> instance.
        /// </summary>
        /// <param name="contextFactory">Context factory.</param>
        public UnitOfWork(IWeatherExperienceContextFactory contextFactory)
        { 
            this.contextFactory = contextFactory;
        }

        /// <inheritdoc cref="IUnitOfWork.CommitAsync"/>
        public async Task CommitAsync()
        {
            await contextFactory.Context.SaveChangesAsync();
        }

        /// <inheritdoc cref="IUnitOfWork.CommitAndCloseAsync"/>
        public async Task CommitAndCloseAsync()
        {
            await contextFactory.Context.SaveChangesAsync();
            await contextFactory.Context.DisposeAsync();
        }

        /// <inheritdoc cref="IUnitOfWork.Rollback"/>
        public async Task RollbackAsync()
        {
            await contextFactory.Context.DisposeAsync();
        }
    }
}