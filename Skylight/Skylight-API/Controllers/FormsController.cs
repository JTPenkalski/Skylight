using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Skylight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(string name)
        {
            return "value";
        }
    }
}
