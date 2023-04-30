using Microsoft.EntityFrameworkCore.ChangeTracking;
using Skylight.Contexts;
using Skylight.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Repositories
{
    /// <inheritdoc cref="IWeatherEventRepository"/>
    public class WeatherEventRepository : BaseRepository<WeatherEvent>, IWeatherEventRepository
    {
        /// <inheritdoc cref="BaseRepository{T}.BaseRepository(WeatherExperienceContext)"/>
        public WeatherEventRepository(WeatherExperienceContext context) : base(context) { }

        public override async Task<bool> Update(WeatherEvent entity)
        {
            // TODO: Make this better, if possible...

            WeatherEvent? existing = await ReadAsync(entity.Id);
            bool success = false;

            if (existing is not null)
            {
                success = true;

                entity.UpdatedDate = DateTime.Now;

                EntityEntry entityEntry = table.Entry(existing);
                entityEntry.CurrentValues.SetValues(entity);

                foreach (NavigationEntry navEntry in entityEntry.Navigations)
                {
                    if (!navEntry.IsLoaded) await navEntry.LoadAsync();

                    if (navEntry.CurrentValue is not null && navEntry.CurrentValue is not ICollection)
                    {
                        NavigationEntry newNavEntry = table.Entry(entity).Navigation(navEntry.Metadata);
                        navEntry.EntityEntry.Context.Entry(navEntry.CurrentValue).CurrentValues.SetValues(newNavEntry.CurrentValue!);
                    }
                }

                UpdateCollection(entityEntry.Context, existing.Locations, entity.Locations, e => e.Id);
                UpdateCollection(entityEntry.Context, existing.Alerts, entity.Alerts, e => e.Id);
            }

            return success;
        }
    }
}