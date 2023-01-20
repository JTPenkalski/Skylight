using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Skylight.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {
        [HttpGet("{formName}")]
        public async Task<ActionResult<string>> Get(string formName)
        {
            string? directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (directory is not null)
            {
                string path = Path.Combine(directory, @$"Forms\{formName}.xml");

                if (System.IO.File.Exists(path))
                {
                    string formXML = await System.IO.File.ReadAllTextAsync(path);

                    Console.WriteLine($"The form template for '{formName}' was found successfully.");
                    return Ok(formXML);
                }

                Console.WriteLine($"The form template for '{formName}' was not found.");
                return NotFound(formName);
            }

            Console.WriteLine("The expected directory containing form XML templates was not found.");
            return NotFound(formName);
        }
    }
}
