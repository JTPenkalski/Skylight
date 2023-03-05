using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Skylight.Models;
using Skylight.Services;
using Skylight.WebModels;
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

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var response = await service.RemoveAsync(id);

            return response.Success ? NoContent() : NotFound();
        }

        [HttpGet("{id}")]
        public virtual async Task<ActionResult<TWebModel>> Get(int id)
        {
            var response = await service.GetAsync(id);

            return response.Success ? Ok(mapper.Map<TModel, TWebModel>(response.Content!)) : NotFound();
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TWebModel>>> GetAll()
        {
            var response = await service.GetAllAsync();

            return response.Success ? Ok(mapper.Map<IEnumerable<TModel>, IEnumerable<TWebModel>>(response.Content!)) : NotFound();
        }

        [HttpPost]
        public virtual async Task<ActionResult<TWebModel>> Post(TWebModel weather)
        {
            var response = await service.AddAsync(mapper.Map<TWebModel, TModel>(weather));

            return response.Success
                ? CreatedAtAction(nameof(Post), GetType().Name, new { id = response.Content!.Id }, mapper.Map<TModel, TWebModel>(response.Content))
                : BadRequest();
        }

        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put(int id, TWebModel weather)
        {
            if (id != weather.Id)
            {
                return BadRequest();
            }

            var response = await service.ModifyAsync(id, mapper.Map<TWebModel, TModel>(weather));

            return response.Success ? NoContent() : NotFound();
        }
    }
}