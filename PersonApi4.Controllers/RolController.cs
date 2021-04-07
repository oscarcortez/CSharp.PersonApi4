using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PersonApi4.Models;
using PersonApi4.Toolkit;

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
    }
}
