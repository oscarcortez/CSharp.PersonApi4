using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using PersonApi4.Models;
using PersonApi4.Models.Contexts;
using Newtonsoft.Json;

namespace PersonApi4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ViewFormattedPersonController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            string result = default;
            using (var context = new PersonDBContext())
            {
                // result = JsonConvert.SerializeObject(context.ViewFormattedPeople.FromSql(storeProcedure).ToList());
                result = JsonConvert.SerializeObject(context.ViewFormattedPeople.ToList());
            }
            return result;
        }
    }
}
