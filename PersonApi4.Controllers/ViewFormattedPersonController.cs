using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PersonApi4.Models;
using PersonApi4.Toolkit;

namespace PersonApi4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewFormattedPersonController : ControllerBase
    {
        private IBusinessObject<ViewFormattedPerson> _businessObject;

        public ViewFormattedPersonController(IBusinessObject<ViewFormattedPerson> businessObject)
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
