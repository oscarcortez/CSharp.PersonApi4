using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PersonApi4.Models;
using PersonApi4.Toolkit;
using Microsoft.AspNetCore.Http;

namespace PersonApi4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolController : ControllerBase
    {
        private IBusinessObject<Rol> _businessObject;

        public RolController(IBusinessObject<Rol> businessObject)
        {
            _businessObject = businessObject;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _businessObject.Query);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Rol rol)
        {
            var result = await _businessObject.Add(rol);
            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
