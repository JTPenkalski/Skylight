using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Services;
using Skylight.WebModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skylight.Controllers
{
    /// <summary>
    /// Represents the shared behavior of all API controllers.
    /// Primarily used for ensuring all dependencies and common functionality is consolidated.
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public abstract class BaseController<TModel, TWebModel> : ControllerBase
        where TModel : BaseIdentifiableModel
        where TWebModel : BaseWebModel
    {
        public const string POST_ERROR = "Object creation failed.";

        protected readonly IConfiguration config;
        protected readonly ILogger logger;
        protected readonly IMapper mapper;
        protected readonly IService<TModel> service;

        /// <summary>
        /// Constructs a new controller instance.
        /// </summary>
        /// <param name="config">Configuration service.</param>
        /// <param name="logger">Logging service.</param>
        /// <param name="mapper">Mapping service.</param>
        /// <param name="service">Business logic service.</param>
        public BaseController(
            IConfiguration config,
            ILogger logger,
            IMapper mapper,
            IService<TModel> service
        )
        {
            this.config = config;
            this.logger = logger;
            this.mapper = mapper;
            this.service = service;
        }

        /// <summary>
        /// Posts a model to the data store.
        /// </summary>
        /// <param name="model">The data of the model to post.</param>
        /// <returns>An HTTP response for the POST request.</returns>
        [HttpPost]
        public virtual async Task<ActionResult<TWebModel>> Post(TWebModel model)
        {
            var response = await service.AddAsync(mapper.Map<TWebModel, TModel>(model));
            
            return response.Success
                ? CreatedAtAction(
                    nameof(Get),
                    GetType().Name.Replace("Controller", string.Empty),
                    new { id = response.Content!.Id },
                    mapper.Map<TModel, TWebModel>(response.Content)
                  )
                : BadRequest();
        }

        /// <summary>
        /// Gets a specific model from the data store.
        /// </summary>
        /// <param name="id">The ID of the model to get.</param>
        /// <returns>An HTTP response for the GET request.</returns>
        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TWebModel>> Get(int id)
        {
            var response = await service.GetAsync(id);

            return response.Success ? Ok(mapper.Map<TModel, TWebModel>(response.Content!)) : NotFound();
        }

        /// <summary>
        /// Gets all models from the data store.
        /// </summary>
        /// <returns>An HTTP response for the GET request.</returns>
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TWebModel>>> GetAll()
        {
            var response = await service.GetAllAsync();

            return response.Success ? Ok(mapper.Map<IEnumerable<TModel>, IEnumerable<TWebModel>>(response.Content!)) : NotFound();
        }

        /// <summary>
        /// Puts a model in the data store.
        /// </summary>
        /// <param name="id">The ID of the model to update.</param>
        /// <param name="model">The data of the updated model to put.</param>
        /// <returns>An HTTP response for the PUT request.</returns>
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, TWebModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var response = await service.ModifyAsync(id, mapper.Map<TWebModel, TModel>(model));

            return response.Success ? NoContent() : NotFound();
        }

        /// <summary>
        /// Deletes a model from the data store.
        /// </summary>
        /// <param name="id">The ID of the model to delete.</param>
        /// <returns>An HTTP response for the DELETE request.</returns>
        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var response = await service.RemoveAsync(id);

            return response.Success ? NoContent() : NotFound();
        }
    }
}