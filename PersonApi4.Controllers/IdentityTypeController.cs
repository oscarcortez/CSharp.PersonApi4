using Microsoft.AspNetCore.Mvc;
// sirve para heredar de ControllerBase

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
    public class IdentityTypeController : ControllerBase
    {
        private IBusinessObject<IdentityType> _businessObject;

        public IdentityTypeController(IBusinessObject<IdentityType> businessObject)
        {
            _businessObject = businessObject;
        }

        [HttpGet]
        public IQueryable Get()
        {
            return _businessObject.Query;
        }
    }
}
