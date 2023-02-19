using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Skylight.Communication;
using Skylight.DatabaseContexts;
using Skylight.DatabaseContexts.Factories;
using Skylight.Models;
using Skylight.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skylight.Services
{
    /// <inheritdoc cref="IWeatherService"/>
    public class WeatherService : BaseService, IWeatherService
    {
        protected readonly IWeatherRepository repository;

        /// <inheritdoc cref="BaseService(IWeatherExperienceContextFactory)"/>
        public WeatherService(ILogger<WeatherService> logger, IUnitOfWork unitOfWork, IWeatherRepository repository)
            : base(logger, unitOfWork)
        { 
            this.repository = repository;
        }

        /// <inheritdoc cref="IWeatherService.AddWeatherAsync(Weather)"/>
        public async Task<ServiceResponse<Weather>> AddWeatherAsync(Weather weather)
        {
            bool success = true;

            try
            {
                await repository.CreateAsync(weather);
                await unitOfWork.CommitAndCloseAsync();
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<Weather>(success, weather);
        }

        /// <inheritdoc cref="IWeatherService.GetWeatherAsync(int)"/>
        public async Task<ServiceResponse<Weather>> GetWeatherAsync(int id)
        {
            Weather? weather = await repository.ReadAsync(id);
            await unitOfWork.CommitAndCloseAsync();

            return new ServiceResponse<Weather>(weather is not null, weather);
        }

        /// <inheritdoc cref="IWeatherService.GetWeatherAsync"/>
        public async Task<ServiceResponse<IEnumerable<Weather>>> GetWeatherAsync()
        {
            IEnumerable<Weather> weather = await repository.ReadAllAsync();
            await unitOfWork.CommitAndCloseAsync();

            return new ServiceResponse<IEnumerable<Weather>>(weather.Any(), weather);
        }

        /// <inheritdoc cref="IWeatherService.ModifyWeatherAsync(int, Weather)"/>
        public async Task<ServiceResponse<Weather>> ModifyWeatherAsync(int id, Weather weather)
        {
            bool success = await repository.ReadAsync(id) is not null;

            try
            {
                if (success)
                {
                    await repository.UpdateAsync(weather);
                    await unitOfWork.CommitAndCloseAsync();
                }
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<Weather>(success, weather);
        }

        /// <inheritdoc cref="IWeatherService.RemoveWeatherAsync(int)"/>
        public async Task<ServiceResponse<Weather>> RemoveWeatherAsync(int id)
        {
            Weather? weather = await repository.ReadAsync(id);
            bool success = weather is not null;

            try
            {
                if (success)
                {
                    await repository.DeleteAsync(id);
                    await unitOfWork.CommitAndCloseAsync();
                }
            }
            catch (Exception ex)
            {
                success = false;
                logger.LogError("{Message}", ex.Message);
            }

            return new ServiceResponse<Weather>(success, weather);
        }
    }
}